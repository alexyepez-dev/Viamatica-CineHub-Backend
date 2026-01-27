using VMT.CineHub.Application.DTOs.Authentication.Register;

namespace VMT.CineHub.Application.Interfaces.UseCases;
public interface IRegisterMappingUseCase
{
    Task Handle(RegisterCommandRequestDto dto);
}