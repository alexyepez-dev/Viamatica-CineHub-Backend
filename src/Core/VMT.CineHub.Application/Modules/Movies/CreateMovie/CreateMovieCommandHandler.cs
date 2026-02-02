using VMT.CineHub.Application.DTOs.Movies.CreateMovie;
using VMT.CineHub.Application.Interfaces.Movies.CreateMovie;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.CreateMovie;
internal sealed class CreateMovieCommandHandler
(
    CineHubDbContext _dbContext,
    IRepository<Movie> _repository
) : ICreateMovieCommandHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;
    private readonly IRepository<Movie> repository = _repository;

    public async Task<Result<CreateMovieCommandResponseDto>> Execute(CreateMovieCommandRequestDto dto)
    {
        var newMovie = Movie.Create
        (
            dto.Name,
            dto.Duration,
            dto.Description,
            dto.Status
        );

        await repository.AddAsync(newMovie);
        await dbContext.SaveChangesAsync();

        var result = new CreateMovieCommandResponseDto($"Movie {dto.Name} successful created.");
        return Result<CreateMovieCommandResponseDto>.Ok(result);
    }
}