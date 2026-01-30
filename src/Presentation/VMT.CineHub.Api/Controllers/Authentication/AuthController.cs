using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.Authentication.Login;
using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Application.Interfaces.Authentication.Login;
using VMT.CineHub.Application.Interfaces.Authentication.Register;

namespace VMT.CineHub.Api.Controllers.Authentication;

[AllowAnonymous]
[Route("api/auth")]
public class AuthController : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register
    (
        [FromBody] RegisterCommandRequestDto dto,
        [FromServices] IRegisterCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );

    [HttpPost("login")]
    public async Task<IActionResult> Login
    (
        [FromBody] LoginCommandRequestDto dto,
        [FromServices] ILoginCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );
}