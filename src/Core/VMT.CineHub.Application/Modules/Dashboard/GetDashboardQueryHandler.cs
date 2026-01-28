using Microsoft.EntityFrameworkCore;
using VMT.CineHub.Application.DTOs.Dashboard;
using VMT.CineHub.Application.Interfaces.Dashboard;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Shared;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Application.Modules.Dashboard;
internal sealed class GetDashboardQueryHandler
(
    CineHubDbContext _dbContext
) : IGetDashboardQueryHandler
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task<Result<GetDashboardQueryResponseDto>> Execute()
    {
        var totalMovieTheaters = await dbContext.Set<MovieTheater>().CountAsync();
        var availableMovieTheaters  = await dbContext.Set<MovieTheater>()
            .CountAsync(x => x.Status == MovieTheaterStatus.Available);

        var totalMovies = await dbContext.Set<Movie>().CountAsync(x => x.Status != MovieStatus.Deleted);
        var totalUsers = await dbContext.Set<User>().CountAsync();

        var result = new GetDashboardQueryResponseDto
        (
            totalMovieTheaters,
            availableMovieTheaters,
            totalMovies,
            totalUsers
        );

        return Result<GetDashboardQueryResponseDto>.Ok(result);
    }
}