using Microsoft.EntityFrameworkCore;
using TechBlogAPI.Entities;

namespace TechBlogAPI.SeedData
{
    public static class BlogPostSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // Create some images
            var image1 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://example.com/image1.jpg"
            };

            var image2 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://example.com/image2.jpg"
            };

            // Create some users
            var user1 = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "User1",
                FirstName = "User1",
                LastName = "User1",
                Email = "user1@example.com"
            };

            var user2 = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "User2",
                FirstName = "User2",
                LastName = "User2",
                Email = "user2@example.com"
            };

            modelBuilder.Entity<Image>().HasData(image1,image2);
            modelBuilder.Entity<AppUser>().HasData(user1,user2);

            var blogPost1 = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "First Blog Post",
                Content = "This is the content of the first blog post.",
                ImageId = image1.Id,
                UserId = user1.Id,
                CreatedBy = "User1"
            };

            var blogPost2 = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Second Blog Post",
                Content = "This is the content of the second blog post.",
                ImageId = image2.Id,
                UserId = user2.Id,
                CreatedBy = "User2"
            };
            var blogPost3 = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Third Blog Post",
                Content = "This is the content of the first blog post.",
                ImageId = image1.Id,
                UserId = user1.Id,
                CreatedBy = "User1"
            };

            var blogPost4 = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Fourth Blog Post",
                Content = "This is the content of the second blog post.",
                ImageId = image2.Id,
                UserId = user2.Id,
                CreatedBy = "User2"
            };

            // Add the blog posts to the model
            modelBuilder.Entity<BlogPost>().HasData(blogPost1, blogPost2,blogPost3, blogPost4);
        }
    }
}
