namespace VMT.CineHub.Application.DTOs.MovieMovieTheater.AssignMovieToMovieTheater;

public sealed record AssignMovieToMovieTheaterCommandRequestDto
(
    string MovieId,
    string MovieTheaterId,
    string PublicationDate,
    string EndDate
);