using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Pages.CreerArticle
{
    public class DetailsArticlesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsArticlesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Article = await _context.Articles
                .Include(a => a.ImageFile)
                .Include(a => a.Commentaires)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (Article == null)
                return NotFound();

            return Page();
        }
    }