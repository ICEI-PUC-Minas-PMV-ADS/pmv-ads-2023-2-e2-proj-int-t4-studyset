﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studyset.Models;
using System.Security.Claims;

namespace studyset.Controllers
{
    [Authorize]
    public class SessoesController : Controller
    {
        private readonly AppDbContext _context;

        public SessoesController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")] // Impedir que a página seja acessada
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sessoes.Include(c => c.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")] // Impedir que a página seja acessada
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
            // Configura a data da sessão como a data atual
            Sessao novaSessao = new Sessao
            {
                DataSessao = DateTime.Today
            };

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");

            // Obtém o ID do aluno logado
            string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtém o histórico de sessões apenas para o aluno logado
            var historico = _context.Sessoes.Include(c => c.Aluno)
                                .Where(s => s.AlunoId == alunoId)
                                .ToList();

            ViewBag.Historico = historico;

            // Calcula a soma do tempo das sessões de estudo do dia atual em minutos
            var totalTempoEstudoMinutes = historico
                .Where(s => s.DataSessao == DateTime.Today)
                .Sum(s => s.DuracaoSessao.TotalMinutes);

            // Define a ViewBag para o total do tempo de estudo
            ViewBag.TotalTempoEstudo = TimeSpan.FromMinutes(totalTempoEstudoMinutes);

            return View(novaSessao);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                // Capitaliza a primeira letra do título
                sessao.TituloSessao = CapitalizeFirstLetter(sessao.TituloSessao);

                if (sessao.DuracaoSessao.TotalMinutes < 1)
                {
                    ModelState.AddModelError("DuracaoSessao", "A sessão deve ter pelo menos 1 minuto de duração.");

                    // Recarrega os dados necessários e retorna a visão com os erros de modelo
                    string alunoIdCreate = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var historicoCreate = _context.Sessoes.Include(c => c.Aluno)
                                                    .Where(s => s.AlunoId == alunoIdCreate)
                                                    .ToList();

                    ViewBag.Historico = historicoCreate;

                    var totalTempoEstudoMinutesCreate = historicoCreate
                        .Where(s => s.DataSessao == DateTime.Today)
                        .Sum(s => s.DuracaoSessao.TotalMinutes);

                    ViewBag.TotalTempoEstudo = TimeSpan.FromMinutes(totalTempoEstudoMinutesCreate);

                    ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario");

                    return View(sessao);
                }

                // Obtém o ID do aluno logado
                string alunoId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Associa o ID do aluno à sessão
                sessao.AlunoId = alunoId;

                _context.Sessoes.Add(sessao);
                await _context.SaveChangesAsync();

                // Armazena o histórico apenas para o aluno logado
                TempData["Historico"] = _context.Sessoes.Include(c => c.Aluno)
                                               .Where(s => s.AlunoId == alunoId)
                                               .ToList();

                // Atualiza a ViewBag para o total do tempo de estudo
                var historico = TempData["Historico"] as List<Sessao>;
                ViewBag.TotalTempoEstudo = TimeSpan.FromMinutes(historico
                    .Where(s => s.DataSessao == DateTime.Today)
                    .Sum(s => s.DuracaoSessao.TotalMinutes));

                return View("Create", sessao);
            }

            return View();
        }

        [Authorize(Roles = "Admin")] // Impedir que a página seja acessada
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

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", sessao.AlunoId);

            return View(sessao);
        }

        [Authorize(Roles = "Admin")] // Impedir que a página seja acessada
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

            ViewData["AlunoId"] = new SelectList(_context.Users, "Id", "NomeUsuario", sessao.AlunoId);

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

            // Redireciona para a página de sessão
            return RedirectToAction("Create", "Sessoes");
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessoes.Any(e => e.Id == id);
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
