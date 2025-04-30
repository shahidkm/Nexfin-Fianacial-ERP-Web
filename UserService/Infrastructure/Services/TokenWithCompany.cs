using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Services
{
    public class TokenWithCompany
    {

        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public TokenWithCompany(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }

        public string GenerateTokenWithCompany(User user,int companyId)
        {
            var secretKey = _jwtSettings["SecretKey"];
            var issuer = _jwtSettings["Issuer"];
            var audience = _jwtSettings["Audience"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret Key is missing in the configuration.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        new Claim(ClaimTypes.Name, user.Fullname),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("CompanyId", companyId.ToString()) // 👈 add custom company claim
    };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
