using FluentValidation;
using VMT.CineHub.Application.DTOs.Authentication.Login;

namespace VMT.CineHub.Application.Validations.Authentication.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommandRequestDto>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(50)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.")
        .Must(x => !string.IsNullOrWhiteSpace(x) && x.Any(char.IsLetter))
        .WithMessage("We're sorry, {PropertyName} must contain at least one letter");

        RuleFor(x => x.Email)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(120)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.")
        .Must(x => !string.IsNullOrWhiteSpace(x) && x.Any(char.IsLetter))
        .WithMessage("We're sorry, {PropertyName} must contain at least one letter");

        RuleFor(x => x.Password)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(50)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters."); ;
    }
}