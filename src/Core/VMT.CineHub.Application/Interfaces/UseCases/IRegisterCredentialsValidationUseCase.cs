using VMT.CineHub.Application.DTOs.Authentication.Login;
using VMT.CineHub.Application.DTOs.Authentication.Register;

namespace VMT.CineHub.Application.Interfaces.UseCases;
public interface IRegisterCredentialsValidationUseCase
{
    Task<bool> Validate(RegisterCommandRequestDto dto);
}