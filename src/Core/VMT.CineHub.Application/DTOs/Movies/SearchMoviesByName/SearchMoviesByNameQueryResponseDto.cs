namespace VMT.CineHub.Application.DTOs.Movies.SearchMoviesByName;
public sealed record SearchMoviesByNameQueryResponseDto
(
    string MovieId,
    string Name,
    int Duration,
    string Status
);