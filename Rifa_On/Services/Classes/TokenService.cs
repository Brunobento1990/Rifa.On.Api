using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Rifa_On.Models;
using Rifa_On.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rifa_On.Services.Classes
{
    public class TokenService : ITokenService
    {
        public Token CreateToken(IdentityUser<int> user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id",user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));

            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credencial,
                expires: DateTime.UtcNow.AddHours(6)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);

        }
    }
}
