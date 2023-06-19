using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Linq;

namespace cosmofolie.Pages.CreerArticle;

[Authorize(Roles = Constants.AdminRole)]
public class CreerModel : PageModel
{

    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CreerModel(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    [BindProperty]
    public CreateVue Article { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var fileName = Guid.NewGuid() + Path.GetExtension(Article.ImageFile.FileName);
        var imageUrl = Path.Combine(_webHostEnvironment.WebRootPath, "imag_stockage", fileName);
        var urls = imageUrl.Split("wwwroot");

        await using var stream = new FileStream(imageUrl, FileMode.Create);

        await Article.ImageFile.CopyToAsync(stream);


        _context.Articles.Add(new Article
        {
            Titre = Article.Titre,
            Contenu = Article.Contenu,
            Image = new Image 
            {
                FileName = fileName,
                Path = urls[1]
            }
        });

        await _context.SaveChangesAsync();
        return RedirectToPage("/Astronomie");
    }
    public class CreateVue
    {
        [Required(ErrorMessage = "Le titre est requis.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le contenu est requis.")]
        public string Contenu { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }
    }
}

