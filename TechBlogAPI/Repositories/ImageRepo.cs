using TechBlogAPI.Entities;
using TechBlogAPI.IRepositories;

namespace TechBlogAPI.Repositories
{
    public class ImageRepo:Repository<Image>, IImageRepo
    {
        public ImageRepo(ApplicationDbContext db):base(db) 
        {
            
        }
    }
}
