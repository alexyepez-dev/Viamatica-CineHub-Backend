using VMT.CineHub.Application.DTOs.MovieTheaters.DeleteMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.DeleteMovieTheater;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.MovieTheaters.DeleteMovieTheater;

internal sealed class DeleteMovieTheaterCommandHandler
(
    IRepository<MovieTheater> _repository,
    CineHubDbContext _dbContext
) : IDeleteMovieTheaterCommandHandler
{
    private readonly IRepository<MovieTheater> repository = _repository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<DeleteMovieTheaterCommandResponseDto>> Execute(string movieTheaterId)
    {
        var movieTheater = await repository.GetByAsync(x => x.MovieTheaterId == movieTheaterId);

        if(movieTheater is null) return Result<DeleteMovieTheaterCommandResponseDto>.Fail
        (
            $"We're sorry, movie theater with {movieTheaterId} not found.",
            ErrorType.NotFound
        );

        repository.Delete(movieTheater);
        await dbContext.SaveChangesAsync();

        var result = new DeleteMovieTheaterCommandResponseDto($"Movie theater successful deleted with id {movieTheaterId}");
        return Result<DeleteMovieTheaterCommandResponseDto>.Ok(result);
    }
}
