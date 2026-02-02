using FluentValidation;
using VMT.CineHub.Application.DTOs.MovieImages.AssignImageToMovie;

namespace VMT.CineHub.Application.Validations.MovieImages.AssignImageToMovie;

public class AssignImageToMovieCommandValidator : AbstractValidator<AssignImageToMovieCommandRequestDto>
{
    public AssignImageToMovieCommandValidator()
    {
        RuleFor(x => x.Url)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(5000)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.");
    }
}