using VMT.CineHub.Application.DTOs.MovieTheaters.UpdateMovieTheater;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieTheaters.UpdateMovieTheater;

public interface IUpdateMovieTheaterCommandHandler
{
    Task<Result<UpdateMovieTheaterCommandResponseDto>> Execute(UpdateMovieTheaterCommandRequestDto dto, string movieTheaterId);
}