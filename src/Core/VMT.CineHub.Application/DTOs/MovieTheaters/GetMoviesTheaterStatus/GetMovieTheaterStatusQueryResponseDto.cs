namespace VMT.CineHub.Application.DTOs.MovieTheaters.GetMoviesTheaterStatus;
public sealed record GetMovieTheaterStatusQueryResponseDto
(
    string MovieTheaterId,
    string Name,
    int TotalMovies,
    string StatusMessage
);