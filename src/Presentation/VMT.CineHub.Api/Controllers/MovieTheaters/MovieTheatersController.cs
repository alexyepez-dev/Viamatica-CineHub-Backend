using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetMoviesTheaterStatus;

namespace VMT.CineHub.Api.Controllers.MovieTheaters;

[Route("api/movie-theaters")]
public class MovieTheatersController : ApiController
{
    [HttpGet("status")]
    public async Task<IActionResult> GetMovieTheaterStatus
    (
        [FromQuery] GetMovieTheaterStatusQueryRequestDto dto,
        [FromServices] IGetMoviesTheaterStatusQueryHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );
}