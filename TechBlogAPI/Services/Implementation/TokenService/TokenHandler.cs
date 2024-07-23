using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechBlogAPI.DTOs.TokenDTOs;
using TechBlogAPI.Entities;
using TechBlogAPI.Services.Abstraction.ITokenService;

namespace TechBlogAPI.Services.Implementation.TokenService
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;   
        }
        public async Task<TokenDTO> CreateAccessTokenAsync(int minute, AppUser user)
        {
            TokenDTO token = new();

            

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken securityToken = new(audience: _configuration["Jwt:Audience"],
                issuer: _configuration["Jwt:Issuer"],
                signingCredentials: signingCredentials,
                expires: token.Expiration,
                notBefore: DateTime.Now,
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken=tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
