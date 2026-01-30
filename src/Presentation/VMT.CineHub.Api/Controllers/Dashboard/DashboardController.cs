using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.Interfaces.Dashboard;

namespace VMT.CineHub.Api.Controllers.Dashboard;

[Authorize]
[Route("api/dashboard")]
public class DashboardController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetDashboard
    (
        [FromServices] IGetDashboardQueryHandler handler
    )
    => FromResult
    (
        await handler.Execute()
    );
}