using VMT.CineHub.Application.DTOs.Authentication.Login;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Authentication.Login;
public interface ILoginCommandHandler
{
    Task<Result<LoginCommandResponseDto>> Execute(LoginCommandRequestDto dto);
}