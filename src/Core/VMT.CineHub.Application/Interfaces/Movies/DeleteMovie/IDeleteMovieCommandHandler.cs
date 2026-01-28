using VMT.CineHub.Application.DTOs.Movies.DeleteMovie;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.DeleteMovie;

public interface IDeleteMovieCommandHandler
{
    Task<Result<DeleteMovieCommandResponseDto>> Execute(DeleteMovieCommandRequestDto dto);
}