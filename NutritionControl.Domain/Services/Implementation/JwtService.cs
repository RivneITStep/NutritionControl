using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<RefreshToken> _tokenRepos;

        public JwtService(IConfiguration configuration,
                          IGenericRepository<RefreshToken> tokenRepos)
        {
            _configuration = configuration;
            _tokenRepos = tokenRepos;
        }

        public string GenerateJwtToken(string email, int userId, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
               
            };

            if (roles.Count()!=0)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles.Aggregate((x, y) => x + "," + y))); 
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateRefreshToken(int userId)
        {
            var refreshToken = await _tokenRepos.GetSingle(x => x.UserId == userId);

            if (refreshToken == null)
            {
                refreshToken = new RefreshToken
                {
                    Token = Guid.NewGuid().ToString(),
                    ExpirationDate = DateTime.Now.AddDays(30),
                    UserId = userId
                };
                await _tokenRepos.Create(refreshToken);
            }
            else
            {
                refreshToken.Token = Guid.NewGuid().ToString();
                refreshToken.ExpirationDate = DateTime.Now.AddDays(30);
                await _tokenRepos.Update(refreshToken);
            }
            return refreshToken.Token;
        }
    }
}