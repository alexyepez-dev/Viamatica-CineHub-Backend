using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.MovieMovieTheater.AssignMovieToMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieMovieTheaters.AssignMovieToMovieTheater;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.MovieMovieTheaters.AssignMovieToMovieTheater;

internal sealed class AssignMovieToMovieTheaterCommandHandler
(
    IRepository<MovieMovieTheater> _movieMovieTheaterRepository,
    IRepository<MovieTheater> _movieTheaterRepository,
    IRepository<Movie> _movieRepository,
    CineHubDbContext _dbContext
) : IAssignMovieToMovieTheaterCommandHandler
{
    private readonly IRepository<MovieMovieTheater> movieMovieTheaterRepository = _movieMovieTheaterRepository;
    private readonly IRepository<MovieTheater> movieTheaterRepository = _movieTheaterRepository;
    private readonly IRepository<Movie> movieRepository = _movieRepository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<AssignMovieToMovieTheaterCommandResponseDto>> Execute(AssignMovieToMovieTheaterCommandRequestDto dto)
    {
        var movie = await movieRepository.GetByAsync(x => x.MovieId == dto.MovieId);

        if (movie is null) return Result<AssignMovieToMovieTheaterCommandResponseDto>.Fail
        (
            $"We're sorry, movie with id {dto.MovieId} not found.",
            ErrorType.NotFound
        );

        var movieTheater = await movieTheaterRepository.GetByAsync(x => x.MovieTheaterId == dto.MovieTheaterId);

        if (movieTheater is null) return Result<AssignMovieToMovieTheaterCommandResponseDto>.Fail
        (
            $"We're sorry, movie theater with id {dto.MovieTheaterId} not found.",
            ErrorType.NotFound
        );

        var exists = await movieMovieTheaterRepository.GetByAsync
        (
            x => x.MovieId == dto.MovieId &&
            x.MovieTheaterId == dto.MovieTheaterId
        );

        if (exists is null == false) return Result<AssignMovieToMovieTheaterCommandResponseDto>.Fail
        (
            $"This movie is already assigned to this theater.",
            ErrorType.Validation
        );

        if (!DateTime.TryParse(dto.PublicationDate, out DateTime publicationDate) ||
            !DateTime.TryParse(dto.EndDate, out DateTime endDate)) return Result<AssignMovieToMovieTheaterCommandResponseDto>.Fail
        (
            $"Invalid date format.",
            ErrorType.Validation
        );

        var assignment = MovieMovieTheater.Create
        (
            dto.MovieId,
            dto.MovieTheaterId,
            publicationDate,
            endDate
        );

        var countMovieAssignToMovieTheater = await dbContext.Set<MovieMovieTheater>().CountAsync(x => x.MovieTheaterId == dto.MovieTheaterId);

        if (countMovieAssignToMovieTheater >= 6)
        {
            movieTheater.ChangeStatus(MovieTheaterStatus.NotAvailable);

            return Result<AssignMovieToMovieTheaterCommandResponseDto>.Fail
            (
                "The movie theater already has the maximum capacity of movies (6).",
                ErrorType.Validation
            );
        }

        await movieMovieTheaterRepository.AddAsync(assignment);
        await dbContext.SaveChangesAsync();

        var result = new AssignMovieToMovieTheaterCommandResponseDto("Successful assign movie to movie theater.");
        return Result<AssignMovieToMovieTheaterCommandResponseDto>.Ok(result);
    }
}