using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Security.Interfaces.Access;
using VMT.CineHub.Security.Interfaces.Construction;

namespace VMT.CineHub.Security.Configurations.Access;
internal sealed class AccessToken
(
    ITokenConstruction _tokenConstruction
) : IAccessToken
{
    private readonly ITokenConstruction tokenConstruction = _tokenConstruction;

    public string GenerateToken(User user) => tokenConstruction.WriteToken
    (
        tokenConstruction.BuildSecurityToken
        (
            tokenConstruction.GetClaims(user),
            tokenConstruction.GetSigningCredentials(tokenConstruction.GetSecurityKey())
        )
    );
}