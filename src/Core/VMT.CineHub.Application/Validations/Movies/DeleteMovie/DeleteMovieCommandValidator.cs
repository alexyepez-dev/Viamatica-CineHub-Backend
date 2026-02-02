using FluentValidation;
using VMT.CineHub.Application.DTOs.Movies.DeleteMovie;

namespace VMT.CineHub.Application.Validations.Movies.DeleteMovie;

public sealed class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommandRequestDto>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.MovieId)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.");
    }
}