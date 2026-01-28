namespace VMT.CineHub.Application.DTOs.Movies.CreateMovie;
public sealed record CreateMovieCommandRequestDto
(
    string Name,
    int Duration
);