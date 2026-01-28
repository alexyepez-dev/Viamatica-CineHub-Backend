namespace VMT.CineHub.Application.DTOs.Movies.SearchMoviesByDate;
public sealed record SearchMoviesByDateQueryResponseDto
(
    string MovieId,
    string Name,
    int Duration,
    string Statusstring,
    DateTime PublicationDate
);