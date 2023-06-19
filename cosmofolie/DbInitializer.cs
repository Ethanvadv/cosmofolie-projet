using cosmofolie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(DbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();


        context.Set<Article>()
            .Add(new Article
            {
                Titre = "Les premières images du télescope spatial James Webb",
                Contenu = " Il y a quelques jours de cela, les astronomes ont dévoilé les premières images prises par le télescope spatial James Webb," +
                " qui orbite autour du Soleil, à une distance d'environ 1,5 million de km de la Terre.\r\n\r\nLes images renvoyées étaient issues d'un" +
                " essai visant à tester l'alignement des instruments de ce fabuleux engin qui a couté la faramineuse somme de 10 milliards de dollars à développer." +
                "Découvrons donc ces premières images de ce télescope 100 fois plus puissants que l'ancien télescope spatial Hubble!",
            }); 
        roleManager.CreateAsync(new IdentityRole(Constants.AdminRole)).GetAwaiter().GetResult();

  
        var user = new User { UserName = "admin@admin.be", Email = "admin@admin.be" };
        userManager.CreateAsync(user, "Azerty123!")
            .GetAwaiter()
            .GetResult();
        userManager.AddToRoleAsync(user, Constants.AdminRole)
            .GetAwaiter()
            .GetResult();

        context.SaveChanges();


    }
}
