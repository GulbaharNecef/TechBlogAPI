using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TechBlogAPI.DTOs.AuthDTOs;
using TechBlogAPI.Services.Abstraction;

namespace TechBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var result = await _authService.Login(request.UsernameOrEmail, request.Password);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _authService.Logout();
            return StatusCode(result.StatusCode, result);
        }
    }
}
