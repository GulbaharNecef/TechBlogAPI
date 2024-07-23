using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TechBlogAPI.Entities;
using TechBlogAPI.SeedData;

namespace TechBlogAPI
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //  relationship between AppUser and BlogPost
            builder.Entity<BlogPost>()
                .HasOne(bp => bp.User)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(bp => bp.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: specify delete behavior

            // relationship between BlogPost and Image
            builder.Entity<BlogPost>()
                .HasOne(bp => bp.Image)
                .WithMany(i => i.BlogPosts)
                .HasForeignKey(bp => bp.ImageId);

            // Applying seed data
            BlogPostSeeder.Seed(builder);

        }
    }
}
