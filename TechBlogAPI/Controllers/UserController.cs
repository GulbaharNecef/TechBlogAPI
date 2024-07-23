using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlogAPI.DTOs.UserDTOs;
using TechBlogAPI.Services.Abstraction;

namespace TechBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO request)
        {
            var result = await _userService.Register(request);
            return StatusCode(result.StatusCode, result);
        }
    }
}
