using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.MovieTheaters.GetMoviesTheaterStatus;
internal sealed class GetMoviesTheaterStatusQueryHandler
(
    CineHubDbContext _dbContext
) : IGetMoviesTheaterStatusQueryHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<GetMovieTheaterStatusQueryResponseDto>> Execute(string name)
    {
        var movieTheater = await dbContext.Set<MovieTheater>()
            .Where(x => x.Name == name)
            .Select
            (
                theater => new
                {
                    movieTheaterId = theater.MovieTheaterId,
                    name = theater.Name,
                    TotalMovies = theater.Movies.Count
                }
            )
            .FirstOrDefaultAsync();

        if (movieTheater is null) return Result<GetMovieTheaterStatusQueryResponseDto>.Fail
        (
            $"Movie theater {name} not found.",
            ErrorType.NotFound
        );

        var message = movieTheater.TotalMovies switch
        {
            < 3 => "Movie theater available.",
            >= 3 and <= 5 => $"Movie theater with {movieTheater.TotalMovies} movies assigned.",
            _ => "Movie theater not available."
        };

        var result = new GetMovieTheaterStatusQueryResponseDto
        (
            movieTheater.movieTheaterId,
            movieTheater.name,
            movieTheater.TotalMovies,
            message
        );
        
        return Result<GetMovieTheaterStatusQueryResponseDto>.Ok(result);
    }
}