using TechBlogAPI.DTOs.UserDTOs;
using TechBlogAPI.ResponseModels;

namespace TechBlogAPI.Services.Abstraction
{
    public interface IUserService
    {
        Task<GenericResponseModel<bool>> Register(UserCreateDTO model);
        //Task<GenericResponseModel<UserGetDTO>> GetUserById(string userId);
    }
}
