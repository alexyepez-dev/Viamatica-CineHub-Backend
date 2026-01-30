using VMT.CineHub.Application.DTOs.MovieTheaters.DeleteMovieTheater;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieTheaters.DeleteMovieTheater;

public interface IDeleteMovieTheaterCommandHandler
{
    Task<Result<DeleteMovieTheaterCommandResponseDto>> Execute(string movieTheaterId);
}