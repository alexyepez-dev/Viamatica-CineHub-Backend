using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Security.Interfaces.Construction;
using VMT.CineHub.Security.Models;

namespace VMT.CineHub.Security.Configurations.Construction;
internal sealed class TokenConstruction
(
    IOptions<JwtSettings> options
) : ITokenConstruction
{
    private readonly JwtSettings settings = options.Value;

    public List<Claim> GetClaims(User user) =>
    [
        new Claim(ClaimTypes.NameIdentifier, user.UserId),
        new Claim("username", user.Username),
        new Claim(ClaimTypes.Email, user.Email.Value)
    ];

    public SymmetricSecurityKey GetSecurityKey() => new(Encoding.UTF8.GetBytes(settings.Key));

    public SigningCredentials GetSigningCredentials(SymmetricSecurityKey key)
        => new(key, SecurityAlgorithms.HmacSha256);

    public JwtSecurityToken BuildSecurityToken(List<Claim> claims, SigningCredentials credentials)
        => new
        (
            issuer: settings.Issuer,
            audience: settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(settings.Expiration),
            signingCredentials: credentials
        );

    public string WriteToken(JwtSecurityToken token)
        => new JwtSecurityTokenHandler().WriteToken(token);
}