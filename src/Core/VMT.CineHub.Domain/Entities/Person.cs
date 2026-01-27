using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Domain.ValueObjects;

namespace VMT.CineHub.Domain.Entities;
public sealed class Person : Entity
{
    public string PersonId { get; private set; }
    public Dni Dni { get; private set; }
    public string Names { get; private set; }
    public string Surnames { get; private set; }

    private Person
    (
        Dni dni,
        string names,
        string surnames
    )
    {
        PersonId = GenerateIdentifier(DomainPrefixes.person);
        Dni = dni;
        Names = names;
        Surnames = surnames;
    }

    public static Person Create
    (
        Dni dni,
        string names,
        string surnames
    )
    => new(dni, names, surnames);
}