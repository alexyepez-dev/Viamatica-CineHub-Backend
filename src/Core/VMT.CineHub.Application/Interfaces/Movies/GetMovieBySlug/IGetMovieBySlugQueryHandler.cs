using VMT.CineHub.Application.DTOs.MovieTheaters.GetMovieBySlug;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.GetMovieBySlug;

public interface IGetMovieBySlugQueryHandler
{
    Task<Result<GetMovieByIdQueryResponseDto>> Execute(string slug);
}