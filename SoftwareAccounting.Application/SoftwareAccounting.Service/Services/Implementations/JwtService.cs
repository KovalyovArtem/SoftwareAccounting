using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.RegisterModels;
using SoftwareAccounting.Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly ILogger<JwtService> _logger;
        private readonly IOptions<AppSettings> _settings;

        public JwtService(ILogger<JwtService> logger,
                          IOptions<AppSettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public async Task<string> GenerateToken(AccountModel model)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", model.UserName),
                new Claim("userName", model.Id.ToString())
            };

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(_settings.Value.AuthSettings.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_settings.Value.AuthSettings.SecretKey)), 
                        SecurityAlgorithms.HmacSha256
                    )
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
