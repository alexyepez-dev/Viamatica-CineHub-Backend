using VMT.CineHub.Application.DTOs.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieTheaters.GetMoviesTheaterStatus;
public interface IGetMoviesTheaterStatusQueryHandler
{
    Task<Result<GetMovieTheaterStatusQueryResponseDto>> Execute(string name);
}