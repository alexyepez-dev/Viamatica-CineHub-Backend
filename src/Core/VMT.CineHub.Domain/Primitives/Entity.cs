using NUlid;

namespace VMT.CineHub.Domain.Primitives;
public abstract class Entity
{
    public static string GenerateIdentifier(string prefix) => $"{prefix}_{Ulid.NewUlid()}";
}