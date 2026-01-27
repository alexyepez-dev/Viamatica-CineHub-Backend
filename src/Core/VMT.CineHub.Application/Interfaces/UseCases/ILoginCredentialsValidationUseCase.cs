using VMT.CineHub.Application.DTOs.Authentication.Login;

namespace VMT.CineHub.Application.Interfaces.UseCases;
public interface ILoginCredentialsValidationUseCase
{
    Task<bool> Validate(LoginCommandRequestDto dto);
}