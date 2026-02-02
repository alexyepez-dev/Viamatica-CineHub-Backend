namespace VMT.CineHub.Application.DTOs.Movies.GetAllMovies;
public sealed record GetAllMoviesQueryModel
(
    string MovieId,
    string Name,
    int Duration,
    string Description,
    List<string> Urls,
    string Slug,
    string Status
);