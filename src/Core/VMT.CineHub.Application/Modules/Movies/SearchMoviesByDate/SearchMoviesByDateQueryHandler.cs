using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Movies.SearchMoviesByDate;
using VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByDate;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.SearchMoviesByDate;

internal sealed class SearchMoviesByDateQueryHandler
(
    IValidateDateUseCase _useCase,
    CineHubDbContext _dbContext
) : ISearchMoviesByDateQueryHandler
{
    private readonly IValidateDateUseCase useCase = _useCase;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<List<SearchMoviesByDateQueryResponseDto>>> Execute(SearchMoviesByDateQueryRequestDto dto)
    {
        if(useCase.Verify(dto.PublicationDate)) return Result<List<SearchMoviesByDateQueryResponseDto>>.Fail
        (
            "Invalid date format. Use YYYY-MM-DD.",
            ErrorType.Validation
        );

        var format = DateTime.TryParse(dto.PublicationDate, out var date);

        var movies = await dbContext.Set<MovieMovieTheater>()
            .Include(x => x.Movie)
            .Where(x => x.PublicationDate == date)
            .Select
            (
                x => new SearchMoviesByDateQueryResponseDto
                (
                    x.Movie!.MovieId,
                    x.Movie.Name,
                    x.Movie.Duration,
                    x.Movie.Status.ToString(),
                    x.PublicationDate
                )
            )
            .ToListAsync();

        if(movies is null || movies.Count == 0) return Result<List<SearchMoviesByDateQueryResponseDto>>.Fail
        (
            $"No movies were found with {dto.PublicationDate} the assigned date",
            ErrorType.NotFound
        );

        return Result<List<SearchMoviesByDateQueryResponseDto>>.Ok(movies);
    }
}