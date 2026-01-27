using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Authentication.Login;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.ValueObjects;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.UseCases;
internal sealed class LoginCredentialsValidationUseCase
(
    CineHubDbContext _dbContext,
    IVerifyHashinPasswordUseCase _useCase
)
{
    private readonly CineHubDbContext dbContext = _dbContext;
    private readonly IVerifyHashinPasswordUseCase useCase = _useCase;

    public async Task<bool> Validate(LoginCommandRequestDto dto, string passwordHashing)
    {
        var emailResult = Email.Create(dto.Email);
        if (!emailResult.IsSuccess) return false;

        var email = emailResult.Value;
        var user = await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email.Value == email.Value);

        if (user is null) return false;

        if (!useCase.Verify(dto.Password, passwordHashing)) return false;

        return true;
    }
}