using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Application.Interfaces.Mappers;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.UseCases;
internal sealed class RegisterMappingUseCase
(
    IMapping _mapping,
    CineHubDbContext _dbContext
)
{
    private readonly IMapping mapping = _mapping;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task Handle(RegisterCommandRequestDto dto)
    {
        var person = mapping.MapPerson(dto);
        var user = mapping.MapUser(dto, person.PersonId);

        dbContext.AddRange(user, person);
        await dbContext.SaveChangesAsync();
    }
}