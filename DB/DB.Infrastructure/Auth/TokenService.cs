using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DB.Infrastructure.Auth;

internal class TokenService : ITokenService
{
    public string GetToken(string email, Guid id, int role)
    {
        var claims = new[] {
            new Claim(ClaimTypes.Email, email),
            new Claim("Id", id.ToString()),
            new Claim(ClaimTypes.Role, role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "Issuer",
            audience: "Audience",
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
            claims: claims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TempSecretKey123123123123123123123")), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
