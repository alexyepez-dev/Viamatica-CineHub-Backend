namespace VMT.CineHub.Application.Interfaces.UseCases;
public interface IVerifyHashinPasswordUseCase
{
    bool Verify(string password, string hashingPassword);
}