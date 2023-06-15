using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Pages;

public class AstronomieModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public List<Article> Articles { get; set; }

    public AstronomieModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Articles = await _context.Articles.ToListAsync();
    }
}
