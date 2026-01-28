namespace VMT.CineHub.Application.DTOs.Dashboard;
public sealed record GetDashboardQueryResponseDto
(
    int TotalMovieTheaters,
    int AvailableMovieTheaters,
    int TotalMovies,
    int TotalUsers
);