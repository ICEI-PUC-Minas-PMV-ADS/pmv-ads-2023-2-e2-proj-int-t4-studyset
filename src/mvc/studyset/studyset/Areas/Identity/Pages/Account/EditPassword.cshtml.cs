using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using studyset.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace studyset.Areas.Identity.Pages.Account
{
    public class EditEmailPasswordModel : PageModel
    {
        private readonly UserManager<Aluno> _userManager;
        private readonly SignInManager<Aluno> _signInManager;

        public EditEmailPasswordModel(UserManager<Aluno> userManager, SignInManager<Aluno> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Id { get; set; }

            [EmailAddress(ErrorMessage = "Endereço de email inválido")]
            [Display(Name = "Novo E-mail")]
            public string NewEmail { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Nova Senha")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "As senhas não coincidem")]
            [Display(Name = "Confirmar Nova Senha")]
            public string ConfirmPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Senha Atual")]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Não foi possível carregar o perfil do usuário '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                Id = user.Id,
                NewEmail = user.Email
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
                return NotFound($"Não foi possível carregar o perfil do usuário '{_userManager.GetUserId(User)}'.");
            }

            // Verifica a senha atual
            if (!string.IsNullOrEmpty(Input.Password))
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, Input.Password);
                if (!passwordCheck)
                {
                    ModelState.AddModelError(string.Empty, "Senha atual incorreta.");
                    return Page();
                }
            }

            // Atualiza o e-mail se fornecido
            if (!string.IsNullOrEmpty(Input.NewEmail) && Input.NewEmail != user.Email)
            {
                user.Email = Input.NewEmail;
                user.UserName = Input.NewEmail;
                var emailChangeResult = await _userManager.UpdateAsync(user);

                if (!emailChangeResult.Succeeded)
                {
                    foreach (var error in emailChangeResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }

            // Atualiza a senha se fornecida
            if (!string.IsNullOrEmpty(Input.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, Input.Password, Input.NewPassword);

                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }

            // Faça login novamente para atualizar o Identity
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToPage("/Account/EditPassword", new { area = "Identity" });
        }
    }
}