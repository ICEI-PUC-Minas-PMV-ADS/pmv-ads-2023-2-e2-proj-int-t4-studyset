using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using studyset.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace studyset.Areas.Identity.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly UserManager<Aluno> _userManager;

        public EditModel(UserManager<Aluno> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Id { get; set; }

            [Required(ErrorMessage = "Obrigat�rio informar o nome")]
            [Display(Name = "Nome")]
            public string NomeUsuario { get; set; }

            [Required(ErrorMessage = "Obrigat�rio informar o tempo dispon�vel para estudos")]
            [Display(Name = "Tempo dispon�vel de estudo")]
            public int TempoEstudo { get; set; }

            [Required(ErrorMessage = "Obrigat�rio informar a meta de estudos")]
            [Display(Name = "Meta de estudo")]
            public int MetaEstudo { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"N�o foi poss�vel carregar o perfil do usu�rio'{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                Id = user.Id,
                NomeUsuario = user.NomeUsuario,
                TempoEstudo = user.TempoEstudo,
                MetaEstudo = user.MetaEstudo
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"N�o foi poss�vel carregar o perfil do usu�rio '{_userManager.GetUserId(User)}'.");
            }

            // Atualiza as propriedades do usu�rio
            user.NomeUsuario = Input.NomeUsuario;
            user.TempoEstudo = Input.TempoEstudo;
            user.MetaEstudo = Input.MetaEstudo;

            // Salva as altera��es
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            return RedirectToPage("/Account/Edit", new { area = "Identity" });
        }
    }
}