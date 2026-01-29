namespace VMT.CineHub.Application.DTOs.MovieTheaters.GetMovieBySlug;

public sealed record GetMovieByIdQueryResponseDto
(
    string MovieId,
    string Name,
    string Description,
    int Duration,
    List<string> Urls,
    string Slug,
    string Status
);