using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.MovieTheaters.GetMovieBySlug;
using VMT.CineHub.Application.Interfaces.Movies.GetMovieBySlug;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Movies.GetMovieBySlug;

internal sealed class GetMovieBySlugQueryHandler
(
    IRepository<Movie> _repository,
    CineHubDbContext _dbContext
) : IGetMovieBySlugQueryHandler
{
    private readonly IRepository<Movie> repository = _repository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<GetMovieByIdQueryResponseDto>> Execute(string slug)
    {
        var movie = await dbContext.Set<Movie>().Include(x => x.MovieImages).FirstOrDefaultAsync(x => x.Slug == slug);

        if(movie is null) return Result<GetMovieByIdQueryResponseDto>.Fail
        (
            $"We're sorry, movie with id or slug {slug}",
            ErrorType.NotFound
        );

        var result = new GetMovieByIdQueryResponseDto
        (
            movie.MovieId,
            movie.Name,
            movie.Description,
            movie.Duration,
            [.. movie.MovieImages.Select(x => x.Url)],
            movie.Slug,
            movie.Status.ToString()
        );
        
        return Result<GetMovieByIdQueryResponseDto>.Ok(result);
    }
}