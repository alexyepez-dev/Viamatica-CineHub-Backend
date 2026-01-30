using VMT.CineHub.Application.DTOs.MovieTheaters.CreateMovie;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieTheaters.CreateMovieTheater;

public interface ICreateMovieTheaterCommandHandler
{
    Task<Result<CreateMovieTheaterCommandResponseDto>> Execute(CreateMovieTheaterCommandRequestDto dto);
}