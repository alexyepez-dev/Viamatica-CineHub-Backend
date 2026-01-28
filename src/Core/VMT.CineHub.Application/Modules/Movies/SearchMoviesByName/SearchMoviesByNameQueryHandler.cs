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
            .Where
            (
                x => EF.Functions.Like(x.Name, $"%{dto.Name.Trim()}%") &&
                x.Status != Domain.Enums.MovieStatus.Deleted
            )
            .Include(x => x.MovieImages)
            .Select
            (
                x => new SearchMoviesByNameQueryResponseDto
                (
                    x.MovieId,
                    x.Name,
                    x.Duration,
                    x.MovieImages
                    .Select(img => img.Url)
                    .ToList(),
                    x.Slug,
                    x.Status.ToString()
                )
            )
            .ToListAsync();

        return Result<List<SearchMoviesByNameQueryResponseDto>>.Ok(movies);
    }
}