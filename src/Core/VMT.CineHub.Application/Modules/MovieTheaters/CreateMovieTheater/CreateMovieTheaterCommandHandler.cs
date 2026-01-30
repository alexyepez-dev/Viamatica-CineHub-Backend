using VMT.CineHub.Application.DTOs.MovieTheaters.CreateMovie;
using VMT.CineHub.Application.Interfaces.MovieTheaters.CreateMovieTheater;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.MovieTheaters.CreateMovieTheater;

internal sealed class CreateMovieTheaterCommandHandler
(
    IRepository<MovieTheater> _repository,
    CineHubDbContext _dbContext
) : ICreateMovieTheaterCommandHandler
{
    private readonly IRepository<MovieTheater> repository = _repository;
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<CreateMovieTheaterCommandResponseDto>> Execute(CreateMovieTheaterCommandRequestDto dto)
    {
        var movieTheaterCreated = MovieTheater.Create(dto.Name);
        await repository.AddAsync(movieTheaterCreated);
        await dbContext.SaveChangesAsync();

        var result = new CreateMovieTheaterCommandResponseDto("Movie theater successful created.");
        return Result<CreateMovieTheaterCommandResponseDto>.Ok(result);
    }
}