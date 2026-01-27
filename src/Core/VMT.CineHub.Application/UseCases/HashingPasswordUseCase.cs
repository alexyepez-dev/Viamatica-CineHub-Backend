using VMT.CineHub.Application.Interfaces.UseCases;

namespace VMT.CineHub.Application.UseCases;
internal sealed class HashingPasswordUseCase : IHashingPasswordUseCase
{
    public string Hashing(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password, 10);
}