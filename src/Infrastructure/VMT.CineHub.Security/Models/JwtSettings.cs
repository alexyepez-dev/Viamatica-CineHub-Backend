namespace VMT.CineHub.Security.Models;
public sealed class JwtSettings
{
    public required string Key { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public int Expiration { get; init; }
}