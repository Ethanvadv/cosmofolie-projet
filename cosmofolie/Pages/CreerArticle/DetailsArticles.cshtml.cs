using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Pages.CreerArticle;

public class DetailsArticlesModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsArticlesModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IndexView Article { get; set; } = default!;

    public async Task OnGetAsync(Guid id)
    {

        Article = await _context.Articles.Include(x => x.Comments)
            .Where(x => x.Id == id)
            .Select(x => new IndexView
            {
                ArticleId = x.Id,
                Titre = x.Titre,
                Contenu = x.Contenu,
                Path = x.Image.Path
            }).SingleAsync();
    }

    public class IndexView
    {
        public Guid ArticleId { get; set; }

        public string Titre { get; set; } = default!;
        public string Contenu { get; set; } = default!;

        public string Path { get; set; } = default!;

        public List<Comment>? Comments { get; set; }
    }
}
