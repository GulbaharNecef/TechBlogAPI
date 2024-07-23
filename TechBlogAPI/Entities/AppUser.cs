using Microsoft.AspNetCore.Identity;

namespace TechBlogAPI.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }

    }
}
