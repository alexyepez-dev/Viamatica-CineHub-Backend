namespace VMT.CineHub.Application.DTOs.Movies.SearchMoviesByDate;
public sealed record SearchMoviesByDateQueryResponseDto
(
    string MovieId,
    string Name,
    string Description,
    int Duration,
    List<string> Urls,
    string Status,
    string Slug,
    DateTime PublicationDate
);