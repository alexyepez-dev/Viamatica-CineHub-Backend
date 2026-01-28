using VMT.CineHub.Application.DTOs.Movies.GetAllMovies;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.GetAllMovies;

public interface IGetAllMoviesQueryHandler
{
    Task<Result<GetAllMoviesQueryResponseDto>> Execute(GetAllMoviesQueryRequestDto dto);
}