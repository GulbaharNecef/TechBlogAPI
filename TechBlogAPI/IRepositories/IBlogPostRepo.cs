using Microsoft.EntityFrameworkCore;
using TechBlogAPI.Entities;

namespace TechBlogAPI.IRepositories
{
    public interface IBlogPostRepo :IRepository<BlogPost>
    {

          Task<BlogPost> GetByIDAsync(string blogPostId);
    }
}
