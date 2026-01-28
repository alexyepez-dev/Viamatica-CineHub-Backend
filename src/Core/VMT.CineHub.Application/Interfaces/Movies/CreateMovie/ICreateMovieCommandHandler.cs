using VMT.CineHub.Application.DTOs.Movies.CreateMovie;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.CreateMovie;

public interface ICreateMovieCommandHandler
{
    Task<Result<CreateMovieCommandResponseDto>> Execute(CreateMovieCommandRequestDto dto);
}