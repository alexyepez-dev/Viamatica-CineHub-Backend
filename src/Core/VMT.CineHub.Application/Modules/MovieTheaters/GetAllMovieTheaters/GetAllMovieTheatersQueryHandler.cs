using VMT.CineHub.Application.DTOs.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Modules.MovieTheaters.GetAllMovieTheaters;

internal sealed class GetAllMovieTheatersQueryHandler
(
    IRepository<MovieTheater> _repository
) : IGetAllMovieTheatersQueryHandler
{
    private readonly IRepository<MovieTheater> repository = _repository;

    public async Task<Result<List<GetAllMovieTheatersQueryResponseDto>>> Execute()
    {
        var movieTheaters = await repository.GetAllAsync();

        if (movieTheaters is null || movieTheaters.Count == 0) return Result<List<GetAllMovieTheatersQueryResponseDto>>.Fail
        (
            "We're sorry, movie theaters not found.",
            ErrorType.NotFound
        );

        var result = movieTheaters.Select
        (
            x => new GetAllMovieTheatersQueryResponseDto(x.MovieTheaterId, x.Name, x.Status.ToString())
        ).ToList();

        return Result<List<GetAllMovieTheatersQueryResponseDto>>.Ok(result);
    }
}