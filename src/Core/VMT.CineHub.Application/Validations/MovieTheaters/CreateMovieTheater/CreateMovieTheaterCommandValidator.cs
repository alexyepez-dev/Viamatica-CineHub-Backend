using FluentValidation;
using VMT.CineHub.Application.DTOs.MovieTheaters.CreateMovie;

namespace VMT.CineHub.Application.Validations.MovieTheaters.CreateMovieTheater;

public sealed class CreateMovieTheaterCommandValidator : AbstractValidator<CreateMovieTheaterCommandRequestDto>
{
    public CreateMovieTheaterCommandValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(100)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.")
        .Must(x => !string.IsNullOrWhiteSpace(x) && x.Any(char.IsLetter))
        .WithMessage("We're sorry, {PropertyName} must contain at least one letter");
    }
}