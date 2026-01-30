using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.MovieTheaters.CreateMovie;
using VMT.CineHub.Application.DTOs.MovieTheaters.UpdateMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.CreateMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.DeleteMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Application.Interfaces.MovieTheaters.UpdateMovieTheater;

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

    [HttpPost]
    public async Task<IActionResult> CreateMovieTheater
    (
        [FromBody] CreateMovieTheaterCommandRequestDto dto,
        [FromServices] ICreateMovieTheaterCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );

    [HttpPatch("{movieTheaterId}")]
    public async Task<IActionResult> UpdateMovieTheater
    (
        string movieTheaterId,
        [FromBody] UpdateMovieTheaterCommandRequestDto dto,
        [FromServices] IUpdateMovieTheaterCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto, movieTheaterId)
    );

    [HttpDelete("{movieTheaterId}")]
    public async Task<IActionResult> DeleteMovieTheater
    (
        string movieTheaterId,
        [FromServices] IDeleteMovieTheaterCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(movieTheaterId)
    );
}