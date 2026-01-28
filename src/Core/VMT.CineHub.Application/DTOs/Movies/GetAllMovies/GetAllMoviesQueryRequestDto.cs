namespace VMT.CineHub.Application.DTOs.Movies.GetAllMovies;
public sealed record GetAllMoviesQueryRequestDto
(
    int Limit,
    int Offset
);