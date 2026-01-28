using VMT.CineHub.Application.DTOs.Dashboard;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.Dashboard;
public interface IGetDashboardQueryHandler
{
    Task<Result<GetDashboardQueryResponseDto>> Execute();
}