using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Pages;

public class AstronomieModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public AstronomieModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<ArticleView> Article { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Article = await _context.Articles
            .Select(x => new ArticleView
            {
                ArticleId = x.Id,
                Titre = x.Titre,
                Contenu = x.Contenu
            })
            .OrderBy(x => x.Titre)
            .ToListAsync();
    }

    public class ArticleView
    {
        public Guid ArticleId { get; init; }
        public string Titre { get; init; } = default!;
        public string Contenu { get; init; } = default!;
    }
}
