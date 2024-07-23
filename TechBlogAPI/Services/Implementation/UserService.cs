using Microsoft.AspNetCore.Identity;
using TechBlogAPI.DTOs.UserDTOs;
using TechBlogAPI.Entities;
using TechBlogAPI.ResponseModels;
using TechBlogAPI.Services.Abstraction;

namespace TechBlogAPI.Services.Implementation
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<GenericResponseModel<bool>> Register(UserCreateDTO model)
        {
            var appUser = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                return new GenericResponseModel<bool>
                {
                    Data = true,
                    StatusCode = 201,
                };
            }
            else
            {
                return new GenericResponseModel<bool>
                {
                    Data = false,
                    StatusCode = 400,
                };
            }
        }
    }
}
