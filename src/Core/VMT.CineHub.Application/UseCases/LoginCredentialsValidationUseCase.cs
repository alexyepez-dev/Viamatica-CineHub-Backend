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
) : ILoginCredentialsValidationUseCase
{
    private readonly CineHubDbContext dbContext = _dbContext;
    private readonly IVerifyHashinPasswordUseCase useCase = _useCase;

    public async Task<bool> Validate(LoginCommandRequestDto dto)
    {
        var user = await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == Email.Create(dto.Email).Value);

        if (user is null) return false;

        return useCase.Verify(dto.Password, user.Password);
    }
}