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
    public string PersonId { get; private set; }
    public Person? Person { get; set; }

    private User
    (
        string username,
        Email email,
        string password,
        string personId
    )
    {
        UserId = GenerateIdentifier(DomainPrefixes.user);
        Username = username;
        Email = email;
        Password = password;
        PersonId = personId;
    }

    public static User Create
    (
        string username,
        Email email,
        string password,
        string personId
    )
    => new(username, email, password, personId);
}