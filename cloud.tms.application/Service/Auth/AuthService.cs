
using cloud.tms.application.DTO;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cloud.tms.application.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _configuration;
        public AuthService(IDbConnection dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _configuration = configuration;
        }
        public async Task<string> AuthenticateAsync(LoginDto loginDto)
        {
            string sql = "SELECT \"Email\", \"CompanyId\", \"PasswordHash\",\"PasswordSalt\" FROM \"Users\" WHERE \"Email\" = @Email";
            var user = await _dbConnection.QuerySingleOrDefaultAsync<dynamic>(sql, new { Email = loginDto.Username });
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return null;
            }
            return GenerateJwtToken(user.Email, user.CompanyId);
        }

        private string GenerateJwtToken(string email, string companyId)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["key"]));

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            //new Claim("Role", role),
            new Claim("CompanyId", companyId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpirationMinutes"])),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
