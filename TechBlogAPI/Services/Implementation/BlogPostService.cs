using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechBlogAPI.DTOs.BlogPostDTOs;
using TechBlogAPI.Entities;
using TechBlogAPI.IRepositories;
using TechBlogAPI.ResponseModels;
using TechBlogAPI.Services.Abstraction;

namespace TechBlogAPI.Services.Implementation
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepo _blogPostRepo;
        private readonly IImageService _imageService;
        private readonly UserManager<AppUser> _userManager;

        public BlogPostService(IBlogPostRepo blogPostRepo, IImageService imageService, UserManager<AppUser> userManager)
        {
            _blogPostRepo = blogPostRepo;
            _imageService = imageService;
            _userManager = userManager;
        }

        public async Task<GenericResponseModel<BlogPostCreateDTO>> CreateBlogPostAsync(BlogPostCreateDTO blogPost, string createdBy, string userId)
        {
            var image = await _imageService.SaveImageAsync(blogPost.CoverPhoto);
            
            var post = new BlogPost
            {
                Title = blogPost.Title,
                Content = blogPost.Content,
                ImageId = image.Id,
                CreatedBy = createdBy,
                UserId = userId
            };

            await _blogPostRepo.AddAsync(post);

            var response = new GenericResponseModel<BlogPostCreateDTO>
            {
                Data = new BlogPostCreateDTO
                {
                    Title = post.Title,
                    Content = post.Content,
                    CoverPhoto = null,
                },
                StatusCode = 201
            };

            return response;
        }

        public async Task<GenericResponseModel<bool>> DeleteBlogPostAsync(string blogPostId)
        {
            try
            {
                if (!Guid.TryParse(blogPostId, out Guid id))
                {
                    return new GenericResponseModel<bool>
                    {
                        Data = false,
                        StatusCode = 400
                    };
                }
                var blogPost = await _blogPostRepo.GetByID(blogPostId);
                if (blogPost == null)
                {
                    return new GenericResponseModel<bool>()
                    {
                        Data = false,
                        StatusCode = 404
                    };
                }
                _blogPostRepo.Remove(blogPost);

                return new GenericResponseModel<bool>
                {
                    Data = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new GenericResponseModel<bool>
                {
                    Data = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<GenericResponseModel<IEnumerable<BlogPostGetDTO>>> GetAllBlogPostsAsync()
        {
            try
            {
                var blogPosts = _blogPostRepo.GetAll();
                if (blogPosts == null || !blogPosts.Any())
                {
                    return new GenericResponseModel<IEnumerable<BlogPostGetDTO>>
                    {
                        Data = null,
                        StatusCode = 404
                    };
                }
                var blogPostDTOs = blogPosts.Select(post => new BlogPostGetDTO
                {
                    Id = post.Id.ToString(),
                    Title = post.Title,
                    Content = post.Content,
                    CoverPhotoUrl = post.Image.Url,
                    User = post.User.FirstName, 
                    CreatedAt = post.CreatedDate
                });

                return new GenericResponseModel<IEnumerable<BlogPostGetDTO>>
                {
                    Data = blogPostDTOs,
                    StatusCode = 200
                };

            }
            catch (Exception ex)
            {
                return new GenericResponseModel<IEnumerable<BlogPostGetDTO>>
                {
                    Data = Enumerable.Empty<BlogPostGetDTO>(),
                    StatusCode = 500
                };
            }

        }

        public async Task<GenericResponseModel<BlogPostGetDTO>> GetBlogPostByIdAsync(string blogPostId)
        {
            try
            {
                var blogPost = await _blogPostRepo.GetByIDAsync(blogPostId);
                if (blogPost == null)
                {
                    return new GenericResponseModel<BlogPostGetDTO>
                    {
                        Data = null,
                        StatusCode = 404
                    };
                }

                var blogPostDto = new BlogPostGetDTO
                {
                    Id = blogPost.Id.ToString(),
                    Title = blogPost.Title,
                    Content = blogPost.Content,
                    CoverPhotoUrl = blogPost.Image?.Url,//todo
                    User =blogPost.CreatedBy,
                    CreatedAt=blogPost.CreatedDate
                };

                var response = new GenericResponseModel<BlogPostGetDTO>
                {
                    Data = blogPostDto,
                    StatusCode = 200
                };
                return response;
            }
            catch(Exception ex) 
            {
                return new GenericResponseModel<BlogPostGetDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }
    }
}
