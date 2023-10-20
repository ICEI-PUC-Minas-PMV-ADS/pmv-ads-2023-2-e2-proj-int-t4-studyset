using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studyset.Models;

namespace studyset.Controllers
{
    public class UsuariosController : Controller {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            var dados = await _context.Usuarios.ToListAsync();

            return View(dados);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if(ModelState.IsValid) {
                /// Verifica se o e-mail já está cadastrado
                var emailExistente = await _context.Usuarios.AnyAsync(u => u.Email == aluno.Email);

                if (emailExistente)
                {
                    ModelState.AddModelError("Email", "Este e-mail já foi cadastrado.");
                    return View(aluno);
                }

                _context.Usuarios.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if (id != aluno.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Mantém a senha original se o campo no formulário estiver vazio
                if (string.IsNullOrEmpty(aluno.Senha))
                {
                    var alunoBanco = await _context.Usuarios.FindAsync(id);
                    if (alunoBanco != null)
                    {
                        aluno.Senha = alunoBanco.Senha;
                    }
                }

                _context.Usuarios.Update(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Usuarios.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
