using cosmofolie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Data
{
    public class ApplicationDbContext :IdentityDbContext<User>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Article>()
                .HasKey(article => article.Id);

            modelBuilder.Entity<Article>()
                .HasOne(article => article.Image)
                .WithOne()
                .HasForeignKey<Image>(article => article.ArticleId);

            modelBuilder.Entity<Article>()
                .HasMany(article => article.Comments) // Définition de la relation un-à-plusieurs
                .WithOne(comment => comment.Article)
                .HasForeignKey(comment => comment.ArticleId); // Clé étrangère dans la table Comment

            modelBuilder.Entity<Image>()
                .HasKey(image => image.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(comment => comment.Id);

            base.OnModelCreating(modelBuilder); 
        }
    }
}