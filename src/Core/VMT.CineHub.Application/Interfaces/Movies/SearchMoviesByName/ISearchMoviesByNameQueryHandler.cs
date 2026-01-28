using VMT.CineHub.Application.DTOs.Movies.SearchMoviesByName;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByName;
public interface ISearchMoviesByNameQueryHandler
{
    Task<Result<List<SearchMoviesByNameQueryResponseDto>>> Execute(SearchMoviesByNameQueryRequestDto dto);
}