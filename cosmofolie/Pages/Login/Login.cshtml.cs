using Azure.Identity;
using cosmofolie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace cosmofolie.Pages.Login;

public class LoginModel : PageModel
{
    private readonly SignInManager<User> _signInManager;

    public LoginModel(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }



    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // L'utilisateur est connecté avec succès, tu peux rediriger vers une autre page
                return RedirectToPage("/Astronomie");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Adresse e-mail ou mot de passe incorrect");
            }
        }

        // Si le modèle n'est pas valide ou si la connexion a échoué, réaffiche le formulaire avec les erreurs
        return Page();
    }
    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}



