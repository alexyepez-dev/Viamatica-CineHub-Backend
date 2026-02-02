using VMT.CineHub.Application.DTOs.Movies.UpdateMovie;
using VMT.CineHub.Application.Interfaces.Movies.UpdateMovie;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.UpdateMovie;
internal sealed class UpdateMovieCommandHandler
(
    IRepository<Movie> _repository,
    CineHubDbContext _dbContext
) : IUpdateMovieCommandHandler
{
    private readonly IRepository<Movie> repository = _repository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<Movie>> Execute(UpdateMovieCommandRequestDto dto, string movieId)
    {
        var movie = await repository.GetByAsync(x => x.MovieId == movieId);

        if (movie is null) return Result<Movie>.Fail
        (
            $"We're sorry, movie {dto.Name} not found",
            ErrorType.NotFound
        );

        movie.Update
        (
            dto.Name,
            dto.Duration,
            dto.Description,
            dto.Status
        );

        await dbContext.SaveChangesAsync();

        var result = new UpdateMovieCommandResponseDto($"Movie {dto.Name} successful modified.");
        return Result<Movie>.Ok(movie);
    }
}