using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studyset.Models;

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

            return View(evento);
        }

        public IActionResult Create() 
        {
            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Agenda.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
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
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Agenda.Any(e => e.Id == id);
        }
    }
}
