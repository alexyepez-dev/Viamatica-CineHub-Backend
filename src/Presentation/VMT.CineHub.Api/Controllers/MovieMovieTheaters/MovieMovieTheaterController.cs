using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.MovieMovieTheater.AssignMovieToMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieMovieTheaters.AssignMovieToMovieTheater;

namespace VMT.CineHub.Api.Controllers.MovieMovieTheaters;

[Route("api/movie-movie-theaters")]
public class MovieMovieTheaterController : ApiController
{
    [HttpPost("assign")]
    public async Task<IActionResult> AssignMovie
    (
        [FromBody] AssignMovieToMovieTheaterCommandRequestDto dto,
        [FromServices] IAssignMovieToMovieTheaterCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );
}