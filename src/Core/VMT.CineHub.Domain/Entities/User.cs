using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Domain.ValueObjects;

namespace VMT.CineHub.Domain.Entities;
public sealed class User : Entity
{
    public string UserId { get; private set; }
    public string Username { get; private set; }
    public Email Email { get; private set; }
    public string Password { get; private set; }

    private User
    (
        string username,
        Email email,
        string password
    )
    {
        UserId = GenerateIdentifier(DomainPrefixes.user);
        Username = username;
        Email = email;
        Password = password;
    }

    public static User Create
    (
        string username,
        Email email,
        string password
    )
    => new(username, email, password);
}