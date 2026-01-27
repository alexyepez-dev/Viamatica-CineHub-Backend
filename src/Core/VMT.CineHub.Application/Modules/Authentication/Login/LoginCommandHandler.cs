using VMT.CineHub.Application.DTOs.Authentication.Login;
using VMT.CineHub.Application.Interfaces.Authentication.Login;
using VMT.CineHub.Application.UseCases;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Security.Interfaces.Access;

namespace VMT.CineHub.Application.Modules.Authentication.Login;
internal sealed class LoginCommandHandler
(
    IAccessToken _accessToken,
    IRepository<User> _repository,
    LoginCredentialsValidationUseCase _useCase
) : ILoginCommandHandler
{
    private readonly IAccessToken accessToken = _accessToken;
    private readonly IRepository<User> repository = _repository;
    private readonly LoginCredentialsValidationUseCase useCase = _useCase;

    public async Task<Result<LoginCommandResponseDto>> Execute(LoginCommandRequestDto dto)
    {
        var credentials = await repository.GetByAsync(dto.Username);

        if(credentials is null) return Result<LoginCommandResponseDto>.Fail
        (
            "We're sorry, credentials not found.",
            ErrorType.NotFound
        );

        if (!await useCase.Validate(dto, credentials.Password)) return Result<LoginCommandResponseDto>.Fail
        (
            "We're sorry, existing credentials.",
            ErrorType.Validation
        );

        var result = new LoginCommandResponseDto(accessToken.GenerateToken(credentials));
        return Result<LoginCommandResponseDto>.Ok(result);
    }
}