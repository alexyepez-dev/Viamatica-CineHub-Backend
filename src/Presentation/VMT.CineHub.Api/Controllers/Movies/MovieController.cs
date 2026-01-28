using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.Movies.CreateMovie;
using VMT.CineHub.Application.DTOs.Movies.SearchMoviesByName;
using VMT.CineHub.Application.DTOs.Movies.UpdateMovie;
using VMT.CineHub.Application.Interfaces.Movies.CreateMovie;
using VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByName;
using VMT.CineHub.Application.Interfaces.Movies.UpdateMovie;

namespace VMT.CineHub.Api.Controllers.Movies;

[Route("api/movies")]
public class MovieController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateMovie
    (
        [FromBody] CreateMovieCommandRequestDto dto,
        [FromServices] ICreateMovieCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );

    [HttpPatch()]
    public async Task<IActionResult> UpdateMovie
    (
        [FromBody] UpdateMovieCommandRequestDto dto,
        [FromQuery] string movieId,
        [FromServices] IUpdateMovieCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto, movieId)
    );

    [HttpGet("search")]
    public async Task<IActionResult> SearchMoviesByName
    (
        [FromQuery] SearchMoviesByNameQueryRequestDto dto,
        [FromServices] ISearchMoviesByNameQueryHandler handler
    )
    => FromResult
    (
        await handler.Execute(dto)
    );
}