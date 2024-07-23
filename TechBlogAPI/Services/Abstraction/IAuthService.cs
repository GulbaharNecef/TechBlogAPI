using TechBlogAPI.DTOs.TokenDTOs;
using TechBlogAPI.ResponseModels;

namespace TechBlogAPI.Services.Abstraction
{
    public interface IAuthService
    {
        Task<GenericResponseModel<TokenDTO>> Login(string usernameOrEmail, string password);
        Task<GenericResponseModel<bool>> Logout();
    }
}
