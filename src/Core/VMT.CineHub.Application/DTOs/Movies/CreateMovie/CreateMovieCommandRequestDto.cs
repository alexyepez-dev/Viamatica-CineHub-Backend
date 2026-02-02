using VMT.CineHub.Domain.Enums;

namespace VMT.CineHub.Application.DTOs.Movies.CreateMovie;
public sealed record CreateMovieCommandRequestDto
(
    string Name,
    int Duration,
    string Description,
    MovieStatus Status
);