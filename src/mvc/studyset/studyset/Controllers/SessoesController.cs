using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studyset.Models;

namespace studyset.Controllers
{
    public class SessoesController : Controller
    {
        private readonly AppDbContext _context;

        public SessoesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sessoes.Include(c => c.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessoes
                .Include(c => c.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                _context.Sessoes.Add(sessao);
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

            var sessao = await _context.Sessoes.FindAsync(id);
            if (sessao == null)
            {
                return NotFound();
            }

            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", sessao.AlunoId);

            return View(sessao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Sessao sessao)
        {
            if (id != sessao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessaoExists(sessao.Id))
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

            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", sessao.AlunoId);

            return View(sessao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessoes
                .Include(c => c.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessao = await _context.Sessoes.FindAsync(id);
            _context.Sessoes.Remove(sessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessoes.Any(e => e.Id == id);
        }
    }
}
