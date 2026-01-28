using VMT.CineHub.Application.DTOs.MovieImages.AssignImageToMovie;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Application.Interfaces.MovieImages.AssignImageToMovie;

public interface IAssignImageToMovieCommandHandler
{
    Task<Result<string>> Execute(string movieId, AssignImageToMovieCommandRequestDto dto);
}