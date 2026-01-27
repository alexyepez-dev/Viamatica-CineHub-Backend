using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.UseCases;
internal sealed class RegisterCredentialsValidationUseCase
(
    CineHubDbContext _dbContext
) : IRegisterCredentialsValidationUseCase
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<bool> Validate(RegisterCommandRequestDto dto) =>
        await dbContext.Set<User>().AnyAsync(x => x.Email.Value == dto.Email) ||
        await dbContext.Set<User>().AnyAsync(x => x.Username == dto.Username) ||
        await dbContext.Set<Person>().AnyAsync(x => x.Dni.Value == dto.Dni);
}