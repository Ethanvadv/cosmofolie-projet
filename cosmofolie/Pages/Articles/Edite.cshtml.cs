using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace cosmofolie.Pages.CreerArticle;

[Authorize(Roles = Constants.AdminRole)]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public EditView Article { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var article = await _context.Articles
            .AsNoTracking()
            .Where(article => article.Id == id)
            .Select(a=> new EditView
            {
                ArticleId = a.Id,
                Titre = a.Titre,
                Contenu = a.Contenu,
                IsTrend = a.IsTrend
            })
            .FirstOrDefaultAsync();

        if (article is null)
        {
            return NotFound();
        }

        Article = article;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var article = await _context.Articles
            .SingleOrDefaultAsync(x => x.Id == Article.ArticleId);

        if (article is null)
        {
            return NotFound();
        }

        article.Titre = Article.Titre;
        article.Contenu = Article.Contenu;
      


        await _context.SaveChangesAsync();
        return RedirectToPage("./Index", new { id = article.Id.ToString() });
    }

    public class EditView
    {
        [Required]
        public Guid ArticleId { get; set; }

        [Required]
        public string Titre { get; set; } = default!;
        [Required]
        public string Contenu { get; set; } = default!;

        [Required]
        public bool IsTrend { get; set; }
    }
}
