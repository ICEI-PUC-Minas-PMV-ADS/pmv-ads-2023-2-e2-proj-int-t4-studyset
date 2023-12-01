using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studyset.Models;
using System.Security.Claims;

namespace studyset.Controllers
{
    public class AgendaController : Controller
    {
        private readonly AppDbContext _context;

        public AgendaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Agenda.Include(c => c.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Agenda
                .Include(c => c.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            // Adiciona a data mínima permitida para o campo de data no formato brasileiro
            ViewData["MinDate"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            return View(evento);
        }

        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");

            // Obtém o ID do aluno logado
            string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtém o histórico de eventos apenas para o aluno logado
            var historico = _context.Agenda.Include(c => c.Aluno)
                                .Where(s => s.AlunoId == alunoId)
                                .ToList();

            ViewBag.Historico = historico;

            // Define a data atual como padrão
            return View(new Evento { DataEvento = DateTime.Now });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento evento)
        {
            // Move a declaração da variável alunoId para o escopo mais amplo
            string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                // Capitaliza a primeira letra do título
                evento.NomeEvento = CapitalizeFirstLetter(evento.NomeEvento);

                // Associa o ID do aluno ao evento
                evento.AlunoId = alunoId;

                // Valida se a data do evento é futura e no formato correto
                if (evento.DataEvento.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("DataEvento", "Escolha uma data futura válida.");
                    ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");
                    ViewBag.Historico = _context.Agenda.Include(c => c.Aluno)
                                          .Where(s => s.AlunoId == alunoId)
                                          .ToList();
                    return View(evento);
                }

                // Inicializa a lista se ViewBag.Historico for nulo
                ViewBag.Historico ??= new List<Evento>();

                _context.Agenda.Add(evento);
                await _context.SaveChangesAsync();

                // Adiciona o novo evento ao histórico
                ViewBag.Historico.Add(evento);

                return RedirectToAction("Create");
            }

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");
            ViewBag.Historico = _context.Agenda.Include(c => c.Aluno)
                                  .Where(s => s.AlunoId == alunoId)
                                  .ToList();
            return View(evento);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Agenda.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", evento.AlunoId);

            return View(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", evento.AlunoId);

            return View(evento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Agenda
                .Include(c => c.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Agenda.FindAsync(id);
            _context.Agenda.Remove(evento);
            await _context.SaveChangesAsync();

            // Retrieve the updated historical events after deletion
            string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updatedHistorico = _context.Agenda.Include(c => c.Aluno)
                                       .Where(s => s.AlunoId == alunoId)
                                       .ToList();

            // Pass the updated historical events to the Create view
            ViewBag.Historico = updatedHistorico;

            return RedirectToAction("Create");
        }

        private bool EventoExists(int id)
        {
            return _context.Agenda.Any(e => e.Id == id);
        }

        // Método para capitalizar a primeira letra de string
        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
