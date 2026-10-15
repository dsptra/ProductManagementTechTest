using AXA.Mandiri.Technical.Test.Application.Contracts;
using AXA.Mandiri.Technical.Test.Domain.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Infrastructure.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        public const int EXPIRY_DURATION = 15;
        private readonly string _secretKey;

        public JwtTokenService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"] ?? JwtInstaller.SecurityKey;
        }

        public JWTDto GenerateJwtToken(string userName)
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(EXPIRY_DURATION);

            var claims = new[]
            {
                new Claim("userName", userName)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials);

            return new JWTDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expiresAt
            };
        }
    }
}
