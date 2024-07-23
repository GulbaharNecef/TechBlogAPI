using TechBlogAPI.Entities;

namespace TechBlogAPI.Services.Abstraction
{
    public interface IImageService
    {
        Task<Image> SaveImageAsync(IFormFile imageFile);
        Task<bool> DeleteImageAsync(string imageId);
    }
}
