using FluentValidation;
using VMT.CineHub.Application.DTOs.MovieMovieTheater.AssignMovieToMovieTheater;

namespace VMT.CineHub.Application.Validations.MovieMovieTheaters.AssignMovieToMovieTheater;

public sealed class AssignMovieToMovieTheaterCommandValidator : AbstractValidator<AssignMovieToMovieTheaterCommandRequestDto>
{
    public AssignMovieToMovieTheaterCommandValidator()
    {
        RuleFor(x => x.MovieId)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.");

        RuleFor(x => x.MovieTheaterId)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.");

        RuleFor(x => x.PublicationDate)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.");

        RuleFor(x => x.EndDate)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.");
    }
}