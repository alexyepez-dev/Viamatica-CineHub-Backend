using Microsoft.AspNetCore.Mvc;
using VMT.CineHub.Api.Abstractions;
using VMT.CineHub.Application.DTOs.MovieImages.AssignImageToMovie;
using VMT.CineHub.Application.Interfaces.MovieImages.AssignImageToMovie;

namespace VMT.CineHub.Api.Controllers.MovieImages;

[Route("api/movie-images")]
public class MovieImagesController : ApiController
{
    [HttpPost("assign/{movieId}")]
    public async Task<IActionResult> AssignImageToMovie
    (
        string movieId,
        [FromBody] AssignImageToMovieCommandRequestDto dto,
        [FromServices] IAssignImageToMovieCommandHandler handler
    )
    => FromResult
    (
        await handler.Execute(movieId, dto)
    );
}