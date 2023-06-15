using cosmofolie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cosmofolie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>()
                .HasKey(article => article.Id);

            modelBuilder.Entity<Article>()
                .HasOne(article => article.Image)
                .WithOne()
                .HasForeignKey<Image>(article => article.ArticleId);

            modelBuilder.Entity<Article>()
                .HasMany(article => article.comments) // Définition de la relation un-à-plusieurs
                .WithOne(comment => comment.Article)
                .HasForeignKey(comment => comment.Id); // Clé étrangère dans la table Comment

            modelBuilder.Entity<Image>()
                .HasKey(image => image.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(comment => comment.Id);
        }
    }
}