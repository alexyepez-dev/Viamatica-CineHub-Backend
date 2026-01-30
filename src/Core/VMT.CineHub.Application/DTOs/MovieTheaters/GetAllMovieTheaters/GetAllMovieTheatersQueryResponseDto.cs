namespace VMT.CineHub.Application.DTOs.MovieTheaters.GetAllMovieTheaters;

public sealed record GetAllMovieTheatersQueryResponseDto
(
    string MovieTheaterId,
    string Name,
    string Status
);