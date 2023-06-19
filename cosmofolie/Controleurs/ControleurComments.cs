//using cosmofolie.Data;
//using cosmofolie.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace cosmofolie.Controleurs;

//public class ControleurComments : Controller
//{
//    private readonly ApplicationDbContext _context;
//private readonly UserManager<IdentityUser> _userManager;

//public ControleurComments(ApplicationDbContext context, UserManager<IdentityUser> userManager)
//{
//    _context = context;
//    _userManager = userManager;
//}

//public IActionResult Article(Guid id)
//{
//    var article = _context.Articles.Include(a => a.Comments).FirstOrDefault(a => a.Id == id);
//    if (article == null)
//    {
//        return NotFound();
//    }
//    return View(article);
//}

//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> AddComment(Guid id, string content)
//{
//    var article = _context.Articles.FirstOrDefault(a => a.Id == id);
//    if (article == null)
//    {
//        return NotFound();
//    }

//    if (!string.IsNullOrEmpty(content))
//    {
//        var user = await _userManager.GetUserAsync(User);
//        var comment = new Comment
//        {
//            Content = content,
//            CreatedAt = DateTime.Now,
//            UserId = user.Id,
//            ArticleId = article.Id
//        };

//        _context.Comments.Add(comment);
//        await _context.SaveChangesAsync();
//    }

//    return RedirectToAction("Article", new { id = article.Id });
//}
//}