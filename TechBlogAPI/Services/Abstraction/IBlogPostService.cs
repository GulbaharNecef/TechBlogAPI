using TechBlogAPI.DTOs.BlogPostDTOs;
using TechBlogAPI.Entities;
using TechBlogAPI.ResponseModels;

namespace TechBlogAPI.Services.Abstraction
{
    public interface IBlogPostService
    {
        Task<GenericResponseModel<BlogPostCreateDTO>> CreateBlogPostAsync(BlogPostCreateDTO blogPost, string createdBy, string userId);       
        Task<GenericResponseModel<BlogPostGetDTO>> GetBlogPostByIdAsync(string blogPostId);
        Task<GenericResponseModel<IEnumerable<BlogPostGetDTO>>> GetAllBlogPostsAsync();
        Task<GenericResponseModel<bool>> DeleteBlogPostAsync(string blogPostId);

        //Task<BlogPost> UpdateBlogPostAsync(Guid blogPostId, string title, string content, IFormFile coverPhoto);
    }
}
