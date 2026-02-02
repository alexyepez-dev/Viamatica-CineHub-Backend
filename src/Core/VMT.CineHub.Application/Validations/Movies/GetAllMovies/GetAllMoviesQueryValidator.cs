using FluentValidation;
using VMT.CineHub.Application.DTOs.Movies.GetAllMovies;

namespace VMT.CineHub.Application.Validations.Movies.GetAllMovies;

public sealed class GetAllMoviesQueryValidator : AbstractValidator<GetAllMoviesQueryRequestDto>
{
    public GetAllMoviesQueryValidator()
    {
        RuleFor(x => x.Limit)
        .GreaterThan(0)
        .WithMessage("Limit cannot be zero.")
        .LessThanOrEqualTo(100)
        .WithMessage("Limit must be between 1 and 100.");

        RuleFor(x => x.Offset)
        .GreaterThanOrEqualTo(0)
        .WithMessage("Offset cannot be negative.");
    }
}