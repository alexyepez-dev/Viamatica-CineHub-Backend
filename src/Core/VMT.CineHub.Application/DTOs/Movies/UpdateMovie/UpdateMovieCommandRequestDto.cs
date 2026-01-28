using VMT.CineHub.Domain.Enums;

namespace VMT.CineHub.Application.DTOs.Movies.UpdateMovie;
public sealed record UpdateMovieCommandRequestDto(
    string Name,
    int Duration,
    MovieStatus Status
);