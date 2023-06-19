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
