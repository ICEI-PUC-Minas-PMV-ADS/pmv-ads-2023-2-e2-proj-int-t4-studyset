using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studyset.Models;
using System.Security.Claims;

namespace studyset.Controllers
{
    public class CronogramasController : Controller
    {
        private readonly AppDbContext _context;

        public CronogramasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cronogramas.Include(c => c.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronogramas
                .Include(c => c.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cronograma == null)
            {
                return NotFound();
            }

            return View(cronograma);
        }

        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");

            // Obtém o ID do aluno logado
            string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtém o histórico de cronogramas apenas para o aluno logado
            var historico = _context.Cronogramas
                                .Include(c => c.Aluno)
                                .Where(c => c.AlunoId == alunoId)
                                .ToList();

            ViewBag.Historico = historico;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cronograma cronograma)
        {
            if (ModelState.IsValid)
            {
                // Capitaliza a primeira letra do título
                cronograma.ConteudoEstudo = CapitalizeFirstLetter(cronograma.ConteudoEstudo);

                // Obtém o ID do aluno logado
                string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Obtém o aluno correspondente ao ID
                var aluno = await _context.Users.FindAsync(alunoId);

                // Associa o ID do aluno ao cronograma
                cronograma.AlunoId = alunoId;

                // Verificar se o cronograma não excede o tempo disponível de estudo do aluno
                var cronogramasDia = _context.Cronogramas
                    .Where(c => c.AlunoId == alunoId && c.DiaEstudo == cronograma.DiaEstudo)
                    .ToList(); // Avaliação no lado do cliente

                var totalHorasDia = cronogramasDia.Sum(c => c.TempoEstudoPadrao);

                if (totalHorasDia + cronograma.TempoEstudoPadrao <= aluno.TempoEstudo)
                {
                    // Se o número total de horas for menor ou igual ao tempo disponível, pode adicionar
                    _context.Cronogramas.Add(cronograma);
                    await _context.SaveChangesAsync();

                    // Atualiza o histórico para o aluno logado
                    ViewBag.Historico = _context.Cronogramas
                                .Include(c => c.Aluno)
                                .Where(c => c.AlunoId == alunoId)
                                .ToList();


                    return View("Create", cronograma);
                }
                else
                {
                    ViewData["ErrorMessage"] = "Não há mais horas disponíveis, atualize seu perfil se precisar";

                    // Atualiza o histórico para o aluno logado
                    ViewBag.Historico = _context.Cronogramas
                                .Include(c => c.Aluno)
                                .Where(c => c.AlunoId == alunoId)
                                .ToList();

                    return View("Create", cronograma);
                }
            }

            // Se houver erros de validação, preencha novamente o dropdown e retorne à view
            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", cronograma.AlunoId);
            return View(cronograma);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronogramas.FindAsync(id);
            if (cronograma == null)
            {
                return NotFound();
            }

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", cronograma.AlunoId);

            return View(cronograma);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cronograma cronograma)
        {
            if (id != cronograma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cronograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CronogramaExists(cronograma.Id))
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

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", cronograma.AlunoId);

            return View(cronograma);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronogramas
                .Include(c => c.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cronograma == null)
            {
                return NotFound();
            }

            return View(cronograma);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cronograma = await _context.Cronogramas.FindAsync(id);
            _context.Cronogramas.Remove(cronograma);
            await _context.SaveChangesAsync();

            // Obtenha o ID do aluno logado
            string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Redirecione para a página de cronogramas com o histórico atualizado
            return RedirectToAction("Create", "Cronogramas", new { area = "", id = alunoId });
        }

        private bool CronogramaExists(int id)
        {
            return _context.Cronogramas.Any(e => e.Id == id);
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