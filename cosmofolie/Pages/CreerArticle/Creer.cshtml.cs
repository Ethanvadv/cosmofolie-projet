using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace cosmofolie.Pages.CreerArticle;

public class CreerModel : PageModel
{

    private readonly ApplicationDbContext _context;

    public CreerModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public CreateVue Article { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Articles.Add(new Article
        {
            Titre = Article.Titre,
            Contenu = Article.Contenu,
            ImageFile = Article.ImageFile,

        });

        await _context.SaveChangesAsync();
        return RedirectToPage("./Astronomie");
    }
    public class CreateVue
    {
        [Required(ErrorMessage = "Le titre est requis.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le contenu est requis.")]
        public string Contenu { get; set; }


        public Image Image { get; set; }
        public IFormFile ImageFile { get; set; }

        public List<Comment> comments { get; set; }

    }
}

