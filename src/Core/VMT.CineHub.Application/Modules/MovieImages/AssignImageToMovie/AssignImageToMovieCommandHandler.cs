using VMT.CineHub.Application.DTOs.MovieImages.AssignImageToMovie;
using VMT.CineHub.Application.Interfaces.MovieImages.AssignImageToMovie;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.MovieImages.AssignImageToMovie;
internal sealed class AssignImageToMovieCommandHandler
(
    IRepository<Movie> _movieRepository,
    IRepository<MovieImage> _movieImageRepository,
    CineHubDbContext _dbContext
) : IAssignImageToMovieCommandHandler
{
    private readonly IRepository<Movie> movieRepository = _movieRepository;
    private readonly IRepository<MovieImage> movieImageRepository = _movieImageRepository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<AssignImageToMovieCommandResponseDto>> Execute(string movieId, AssignImageToMovieCommandRequestDto dto)
    {
        var movie = await movieRepository.GetByAsync(x => x.MovieId == movieId);

        if (movie is null) return Result<AssignImageToMovieCommandResponseDto>.Fail
        (
            $"We're sorry, movie with id {movieId} not found.",
            ErrorType.NotFound
        );

        var movieImage = MovieImage.Create(dto.Url, movieId);

        await movieImageRepository.AddAsync(movieImage);
        await dbContext.SaveChangesAsync();

        var result = new AssignImageToMovieCommandResponseDto("adding successful image to movie.");
        return Result<AssignImageToMovieCommandResponseDto>.Ok(result);
    }
}