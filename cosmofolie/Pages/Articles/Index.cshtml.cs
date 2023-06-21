using cosmofolie.Data;
using cosmofolie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace cosmofolie.Pages.Articles;

public class DetailsArticlesModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public DetailsArticlesModel(ApplicationDbContext context,UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IndexView Article { get; set; } = default!;

    [BindProperty]
    public CreateView CreateViews { get; set; } = default!;

    public async Task OnGetAsync(Guid id)
    {

        Article = await _context.Articles.Include(x => x.Comments)
            .Where(x => x.Id == id)
            .Select(x => new IndexView
            {
                ArticleId = x.Id,
                Titre = x.Titre,
                Contenu = x.Contenu,
                Path = x.Image.Path,
                Comments = x.Comments
            }).SingleAsync();
        CreateViews = new CreateView()
        {
            ArticleId = id,
        };
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage("./Index",new {Id = CreateViews.ArticleId});
        }
        var user = await _userManager.GetUserAsync(User);
        // Ajoutez le Comment à la base de données et enregistrez les modifications
        _context.Comments.Add(new Comment
        {
            Content = CreateViews.Content,
            CreatedAt = DateTime.Now,
            User = user!,
            ArticleId = CreateViews.ArticleId
        });
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index", new { Id = CreateViews.ArticleId });
    }

    public class CreateView
    {
        [Required]
        public string Content { get; set; } = default!;
        [Required]
        public Guid ArticleId { get; set; }
    }
    public class IndexView
    {
        public Guid ArticleId { get; set; }

        public string Titre { get; set; } = default!;
        public string Contenu { get; set; } = default!;

        public string Path { get; set; } = default!;

        public List<cosmofolie.Models.Comment>? Comments { get; set; }
    }
}


