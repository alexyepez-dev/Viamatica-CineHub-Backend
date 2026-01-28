using VMT.CineHub.Application.DTOs.Movies.SearchMoviesByDate;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByDate;
public interface ISearchMoviesByDateQueryHandler
{
    Task<Result<List<SearchMoviesByDateQueryResponseDto>>> Execute(SearchMoviesByDateQueryRequestDto dto);
}