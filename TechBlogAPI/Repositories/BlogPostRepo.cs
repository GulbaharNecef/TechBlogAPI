using Microsoft.EntityFrameworkCore;
using TechBlogAPI.Entities;
using TechBlogAPI.Exceptions;
using TechBlogAPI.IRepositories;

namespace TechBlogAPI.Repositories
{
    public class BlogPostRepo:Repository<BlogPost>, IBlogPostRepo
    {
        private readonly ApplicationDbContext _context;
        public BlogPostRepo(ApplicationDbContext db): base(db)
        {
            _context = db;
        }
        public async Task<BlogPost> GetByIDAsync(string blogPostId)
        {
            bool checkIdFormat = Guid.TryParse(blogPostId, out Guid result);
            if (!checkIdFormat) {
                throw new InvalidIdFormatException(blogPostId);
            }
            return await _context.BlogPosts
                .Include(bp => bp.Image) 
                .FirstOrDefaultAsync(bp => bp.Id == result);
        }
    }
}
