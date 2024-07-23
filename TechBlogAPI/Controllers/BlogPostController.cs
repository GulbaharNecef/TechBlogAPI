using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechBlogAPI.DTOs.BlogPostDTOs;
using TechBlogAPI.Entities;
using TechBlogAPI.Services.Abstraction;

namespace TechBlogAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        private readonly UserManager<AppUser> _userManager;
        public BlogPostController(IBlogPostService blogPostService, UserManager<AppUser> userManager)
        {
            _blogPostService = blogPostService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetTechBlogs()
        {
            var result = await _blogPostService.GetAllBlogPostsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTechBlog(string id)
        {
            var result = await _blogPostService.GetBlogPostByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostTechBlog([FromForm]BlogPostCreateDTO blogPostCreateDTO)
        {
            var user = await _userManager.GetUserAsync(User); // Get the currently logged-in user
            var createdBy = user.FirstName;
            var result = await _blogPostService.CreateBlogPostAsync(blogPostCreateDTO, createdBy,user.Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechBlog(string id)
        {
            var result = await _blogPostService.DeleteBlogPostAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}

