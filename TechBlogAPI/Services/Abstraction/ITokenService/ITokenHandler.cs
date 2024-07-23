using TechBlogAPI.DTOs.TokenDTOs;
using TechBlogAPI.Entities;

namespace TechBlogAPI.Services.Abstraction.ITokenService
{
    public interface ITokenHandler
    {
        Task<TokenDTO> CreateAccessTokenAsync(int minute, AppUser user);
    }
}
