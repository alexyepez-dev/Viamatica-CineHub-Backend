using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetMoviesTheaterStatus;

namespace VMT.CineHub.Api.Controllers.MovieTheaters;

[Route("api/movie-theaters")]
public class MovieTheatersController : ApiController
{
    [HttpGet("status/{name}")]
    public async Task<IActionResult> GetMovieTheaterStatus
    (
        string name,
        [FromServices] IGetMoviesTheaterStatusQueryHandler handler
    )
    => FromResult
    (
        await handler.Execute(name)
    );

    [HttpGet]
    public async Task<IActionResult> GetAllMovieTheaters
    (
        [FromServices] IGetAllMovieTheatersQueryHandler handler
    )
    => FromResult
    (
        await handler.Execute()
    );
}