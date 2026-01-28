using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Movies.CreateMovie;
using VMT.CineHub.Application.Interfaces.Movies.CreateMovie;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.CreateMovie;
internal sealed class CreateMovieCommandHandler
(
    CineHubDbContext _dbContext
) : ICreateMovieCommandHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<CreateMovieCommandResponseDto>> Execute(CreateMovieCommandRequestDto dto)
    {
        var movieId = Entity.GenerateIdentifier(DomainPrefixes.movie);
        var slug = Entity.GenerateSlug(dto.Name);

        await dbContext.Database.ExecuteSqlRawAsync
        (
            "EXEC CreateMovie @MovieId, @Name, @Duration, @Status, @Slug",
            new SqlParameter("@MovieId", movieId),
            new SqlParameter("@Name", dto.Name),
            new SqlParameter("@Duration", dto.Duration),
            new SqlParameter("@Status", MovieStatus.NowPlaying.ToString()),
            new SqlParameter("@Slug", slug)
        );

        var result = new CreateMovieCommandResponseDto($"Movie {dto.Name} successful created.");
        return Result<CreateMovieCommandResponseDto>.Ok(result);
    }
}