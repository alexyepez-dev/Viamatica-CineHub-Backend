using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Security.Interfaces.Construction;
public interface ITokenConstruction
{
    List<Claim> GetClaims(User user);
    SymmetricSecurityKey GetSecurityKey();
    SigningCredentials GetSigningCredentials(SymmetricSecurityKey key);
    JwtSecurityToken BuildSecurityToken(List<Claim> claims, SigningCredentials credentials);
    string WriteToken(JwtSecurityToken token);
}
