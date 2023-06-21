using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace cosmofolie.Pages.Accunt;

public class InscriptionModel : PageModel
{
    private readonly UserManager<User> _userManager;

    public InscriptionModel(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string adresseemail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string motdepasse { get; set; }
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
           if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.adresseemail, Email = Input.adresseemail };

                var result = await _userManager.CreateAsync(user, Input.motdepasse);
                if (result.Succeeded)
                {
                    // Gérer ici les actions à effectuer après l'inscription réussie, par exemple, rediriger vers une page de connexion
                    return RedirectToPage("/Login/Login");
                }
            return Page();
            }
        
        
            ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de l'inscription.");
            return Page();
        
    }
}


