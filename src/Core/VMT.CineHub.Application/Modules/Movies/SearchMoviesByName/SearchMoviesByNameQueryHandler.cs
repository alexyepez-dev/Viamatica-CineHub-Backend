using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Movies.SearchMoviesByName;
using VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByName;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.SearchMoviesByName;
internal sealed class SearchMoviesByNameQueryHandler
(
    CineHubDbContext _dbContext
) : ISearchMoviesByNameQueryHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<List<SearchMoviesByNameQueryResponseDto>>> Execute(SearchMoviesByNameQueryRequestDto dto)
    {
        var movies = await dbContext.Set<Movie>()
            .Where(x => EF.Functions.Like(x.Name, $"%{dto.Name.Trim()}%") && x.Status != Domain.Enums.MovieStatus.Deleted)
            .Select
            (
                x => new SearchMoviesByNameQueryResponseDto
                (
                    x.MovieId,
                    x.Name,
                    x.Duration,
                    x.Status.ToString()
                )
            )
            .ToListAsync();

        return Result<List<SearchMoviesByNameQueryResponseDto>>.Ok(movies);
    }
}