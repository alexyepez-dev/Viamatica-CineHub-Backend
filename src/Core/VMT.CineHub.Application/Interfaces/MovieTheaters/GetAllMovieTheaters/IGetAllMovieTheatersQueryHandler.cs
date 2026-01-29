using VMT.CineHub.Application.DTOs.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieTheaters.GetAllMovieTheaters;
public interface IGetAllMovieTheatersQueryHandler
{
    Task<Result<List<GetAllMovieTheatersQueryResponseDto>>> Execute();
}