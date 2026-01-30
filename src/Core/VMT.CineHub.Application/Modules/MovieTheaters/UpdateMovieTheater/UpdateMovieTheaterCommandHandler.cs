using VMT.CineHub.Application.DTOs.MovieTheaters.UpdateMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.UpdateMovieTheater;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.MovieTheaters.UpdateMovieTheater;

internal sealed class UpdateMovieTheaterCommandHandler
(
    IRepository<MovieTheater> _repository,
    CineHubDbContext _dbContext
) : IUpdateMovieTheaterCommandHandler
{
    private readonly IRepository<MovieTheater> repository = _repository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<UpdateMovieTheaterCommandResponseDto>> Execute
    (
        UpdateMovieTheaterCommandRequestDto dto, 
        string movieTheaterId
    )
    {
        var movieTheater = await repository.GetByAsync(x => x.MovieTheaterId == movieTheaterId);

        if(movieTheater is null) return Result<UpdateMovieTheaterCommandResponseDto>.Fail
        (
            $"We're sorry, movie theater with {movieTheaterId} not found.",
            ErrorType.NotFound
        );

        movieTheater.Update(dto.Name);
        await dbContext.SaveChangesAsync();

        var result = new UpdateMovieTheaterCommandResponseDto($"Movie Theater successful updated with id {movieTheaterId}");
        return Result<UpdateMovieTheaterCommandResponseDto>.Ok(result);
    }
}