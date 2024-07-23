using Microsoft.AspNetCore.Identity;
using TechBlogAPI.DTOs.TokenDTOs;
using TechBlogAPI.Entities;
using TechBlogAPI.ResponseModels;
using TechBlogAPI.Services.Abstraction;
using TechBlogAPI.Services.Abstraction.ITokenService;

namespace TechBlogAPI.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private IConfiguration _configuration;
        public AuthService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, ITokenHandler tokenHandler,IConfiguration configuration )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }
        public async Task<GenericResponseModel<TokenDTO>> Login(string usernameOrEmail, string password)
        {
            var user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            }
            if (user == null)
            {
                return new GenericResponseModel<TokenDTO>()
                {
                    Data = null,
                    StatusCode = 404
                };
            }
            SignInResult result = await  _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                TokenDTO token = await _tokenHandler.CreateAccessTokenAsync(Int32.Parse(_configuration["Jwt:AccessTokenLifeTimeInMinutes"]), user);
                return new()
                {
                    Data = token,
                    StatusCode = 200
                };
            }
            return new GenericResponseModel<TokenDTO>
            {
                Data = null,
                StatusCode = 401
            };
        }

        public async Task<GenericResponseModel<bool>> Logout()
        {
            await _signInManager.SignOutAsync();
            return new GenericResponseModel<bool> { Data = true, StatusCode =200 };
        }
    }
}
