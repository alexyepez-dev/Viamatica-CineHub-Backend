namespace VMT.CineHub.Application.DTOs.Movies.GetAllMovies;

public sealed record GetAllMoviesQueryResponseDto
(
    int Pages,
    List<GetAllMoviesQueryModel> Movies
);