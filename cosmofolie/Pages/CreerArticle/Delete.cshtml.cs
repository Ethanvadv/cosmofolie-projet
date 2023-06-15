using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Article Article { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        Article = await _context.Articles.FindAsync(id);

        if (Article == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var article = await _context.Articles.FindAsync(Article.Id);

        if (article == null)
            return NotFound();

        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

