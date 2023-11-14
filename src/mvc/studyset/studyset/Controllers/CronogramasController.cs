using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studyset.Models;

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
            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cronograma cronograma)
        {
            if (ModelState.IsValid)
            {
                _context.Cronogramas.Add(cronograma);
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

            var cronograma = await _context.Cronogramas.FindAsync(id);
            if (cronograma == null)
            {
                return NotFound();
            }

            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", cronograma.AlunoId);

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

            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", cronograma.AlunoId);

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
            return RedirectToAction(nameof(Index));
        }

        private bool CronogramaExists(int id)
        {
            return _context.Cronogramas.Any(e => e.Id == id);
        }
    }
}
