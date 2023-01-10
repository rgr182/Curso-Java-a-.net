using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.Utils.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Curso_Java_a_.net.Utils.Security
{
    public class AuthUtils : IAuthUtils
    {
        IConfiguration _configuration;

        public AuthUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJWT(Users user)
        {            
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));           

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Exp, user.Grade.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()),
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);            
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
