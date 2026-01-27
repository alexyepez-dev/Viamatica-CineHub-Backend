using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Application.Interfaces.Authentication.Register;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Modules.Authentication.Register;
internal sealed class RegisterCommandHandler
(
    IRegisterMappingUseCase _mappingUseCase,
    IRegisterCredentialsValidationUseCase _credentialsUseCase
) : IRegisterCommandHandler
{
    private readonly IRegisterMappingUseCase mappingUseCase = _mappingUseCase;
    private readonly IRegisterCredentialsValidationUseCase credentialsUseCase = _credentialsUseCase;

    public async Task<Result<RegisterCommandResponseDto>> Execute(RegisterCommandRequestDto dto)
    {
        if (await credentialsUseCase.Validate(dto)) return Result<RegisterCommandResponseDto>.Fail
        (
            "We're sorry, existing credentials.",
            ErrorType.Validation
        );
        
        await mappingUseCase.Handle(dto);

        var result = new RegisterCommandResponseDto("Hello, welcome to my application.");
        return Result<RegisterCommandResponseDto>.Ok(result);
    }
}