using VMT.CineHub.Application.DTOs.Movies.DeleteMovie;
using VMT.CineHub.Application.Interfaces.Movies.DeleteMovie;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.DeleteMovie;

internal sealed class DeleteMovieCommandHandler
(
    CineHubDbContext _dbContext,
    IRepository<Movie> _repository
) : IDeleteMovieCommandHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;
    private readonly IRepository<Movie> repository = _repository;

    public async Task<Result<DeleteMovieCommandResponseDto>> Execute(DeleteMovieCommandRequestDto dto)
    {
        var movie = await repository.GetByAsync(x => x.MovieId == dto.MovieId);

        if (movie is null) return Result<DeleteMovieCommandResponseDto>.Fail
        (
            $"Movie with id {dto.MovieId} not found.",
            ErrorType.NotFound
        );

        movie.ChangeStatusToDeleted();
        await dbContext.SaveChangesAsync();

        var result = new DeleteMovieCommandResponseDto($"Movie with id {dto.MovieId} successful deleted.");
        return Result<DeleteMovieCommandResponseDto>.Ok(result);
    }
}