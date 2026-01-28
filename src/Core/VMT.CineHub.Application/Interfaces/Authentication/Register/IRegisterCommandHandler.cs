using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Authentication.Register;

public interface IRegisterCommandHandler
{
    Task<Result<RegisterCommandResponseDto>> Execute(RegisterCommandRequestDto dto);
}