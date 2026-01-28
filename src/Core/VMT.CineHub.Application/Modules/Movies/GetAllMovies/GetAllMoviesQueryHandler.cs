using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Movies.GetAllMovies;
using VMT.CineHub.Application.Interfaces.Movies.GetAllMovies;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.GetAllMovies;

internal sealed class GetAllMoviesQueryHandler
(
    CineHubDbContext _dbContext
) : IGetAllMoviesQueryHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<GetAllMoviesQueryResponseDto>> Execute(GetAllMoviesQueryRequestDto dto)
    {
        var baseQuery = dbContext.Set<Movie>().Where(x => x.Status != MovieStatus.Deleted);

        var countItems = await baseQuery.CountAsync();

        if (countItems == 0) return Result<GetAllMoviesQueryResponseDto>.Fail
        (
            "We're sorry, movies not found.",
            ErrorType.NotFound
        );

        var totalPages = (int)Math.Ceiling((double)countItems / dto.Limit);

        var movies = await baseQuery
            .OrderBy(x => x.MovieId)
            .Skip(dto.Offset)
            .Take(dto.Limit)
            .Select(x => new GetAllMoviesQueryModel
            (
                x.MovieId,
                x.Name,
                x.Duration,
                x.MovieImages
                    .Select(img => img.Url)
                    .ToList(),
                x.Slug,
                x.Status.ToString()
            ))
            .ToListAsync();

        var result = new GetAllMoviesQueryResponseDto(totalPages, movies);

        return Result<GetAllMoviesQueryResponseDto>.Ok(result);
    }
}