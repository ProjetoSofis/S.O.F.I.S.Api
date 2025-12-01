using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Sofis.Api.Infrastructure.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;
        private readonly string _audience;
        public readonly double _durationInMinutes;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _issuer = _configuration["Jwt:Issuer"];
            _audience = _configuration["Jwt:Audience"];
            _durationInMinutes = Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]);
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        }
        public string GenerateToken(Employee employee)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
            {
                // Sub (Subject) é o ID principal do usuário
                new Claim(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
                
                // Jti (JWT ID) é um ID único para este token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                
                // Email do usuário
                new Claim(JwtRegisteredClaimNames.Email, employee.Email),
                
                // Role (Função) - Essencial para autorização
                new Claim(ClaimTypes.Role, employee.Role.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.UtcNow.AddMinutes(_durationInMinutes),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
