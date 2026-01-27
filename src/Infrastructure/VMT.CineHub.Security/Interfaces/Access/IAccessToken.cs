using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Security.Interfaces.Access;
public interface IAccessToken
{
    string GenerateToken(User user);
}