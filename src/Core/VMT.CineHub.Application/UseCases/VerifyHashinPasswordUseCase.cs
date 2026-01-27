using VMT.CineHub.Application.Interfaces.UseCases;

namespace VMT.CineHub.Application.UseCases;
internal sealed class VerifyHashinPasswordUseCase : IVerifyHashinPasswordUseCase
{
    public bool Verify(string password, string hashingPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashingPassword);
}