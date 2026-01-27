using FluentValidation;
using VMT.CineHub.Application.DTOs.Authentication.Register;

namespace VMT.CineHub.Application.Validations.Authentication.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommandRequestDto>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Dni)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(10)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.");

        RuleFor(x => x.Names)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(50)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.")
        .Must(x => !string.IsNullOrWhiteSpace(x) && x.Any(char.IsLetter))
        .WithMessage("We're sorry, {PropertyName} must contain at least one letter");

        RuleFor(x => x.Surnames)
        .NotEmpty()
        .WithMessage("We're sorry, {PropertyName} is required.")
        .MaximumLength(50)
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.")
        .Must(x => !string.IsNullOrWhiteSpace(x) && x.Any(char.IsLetter))
        .WithMessage("We're sorry, {PropertyName} must contain at least one letter");
        
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
        .WithMessage("We're sorry, {PropertyName} has maximum {TotalLength} characters.");
    }
}