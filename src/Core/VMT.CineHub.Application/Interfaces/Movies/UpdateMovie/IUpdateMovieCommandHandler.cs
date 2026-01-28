using VMT.CineHub.Application.DTOs.Movies.UpdateMovie;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.UpdateMovie;
public interface IUpdateMovieCommandHandler
{
    Task<Result<UpdateMovieCommandResponseDto>> Execute(UpdateMovieCommandRequestDto dto, string movieId);
}