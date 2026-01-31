using VMT.CineHub.Application.DTOs.MovieMovieTheater.AssignMovieToMovieTheater;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieMovieTheaters.AssignMovieToMovieTheater;

public interface IAssignMovieToMovieTheaterCommandHandler
{
    Task<Result<AssignMovieToMovieTheaterCommandResponseDto>> Execute(AssignMovieToMovieTheaterCommandRequestDto dto);
}