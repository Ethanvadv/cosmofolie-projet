using cosmofolie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Pages.CreerArticle
{
    public class Deletmodel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Deletmodel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeleteView Articles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var article = await _context.Articles
                .Select(a => new DeleteView
                {
                    ArticleId = a.Id,
                    Titre = a.Titre,
                    ImageId = a.ImageId
                }).SingleOrDefaultAsync();

            if (article is null)
            {
                return NotFound();
            }

            Articles = article;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(x => x.Id == id);

            if (article is not null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Astronomie");
        }

        public class DeleteView
        {
            public Guid ArticleId { get; set; }
            public string Titre { get; set; } = default!;
            public Guid ImageId { get; set; }
        }
    }
}
