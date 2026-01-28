using FluentValidation;
using VMT.CineHub.Application.DTOs.Movies.UpdateMovie;

namespace VMT.CineHub.Application.Validations.Movies.UpdateMovie;
public sealed class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommandRequestDto>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(100)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.")
        .Must(x => !string.IsNullOrWhiteSpace(x) && x.Any(char.IsLetter))
        .WithMessage("We're sorry, {PropertyName} must contain at least one letter");

        RuleFor(x => x.Duration)
        .GreaterThan(0)
        .WithMessage("We're sorry, {PropertyName} has value zero.");

        RuleFor(x => x.Status)
        .IsInEnum();
    }
}