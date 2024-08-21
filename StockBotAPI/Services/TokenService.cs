using Microsoft.IdentityModel.Tokens;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockBotAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _securityKey;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_SECRET_KEY"]!));
            
        }
        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email!),
                new Claim(JwtRegisteredClaimNames.Name, appUser.UserName!)
            };

            var encrypt = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = encrypt,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
        }
    }
}
