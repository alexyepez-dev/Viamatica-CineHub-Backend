using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Errors;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Domain.ValueObjects;
public sealed class Email
{
    public string Value { get; private set; }

    private Email(string value) => Value = value;

    public const int MaxLength = 120;

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return Result<Email>.Fail
        (
            DomainErrors.FielRequired("email"),
            ErrorType.Validation
        );

        if (value.Length > MaxLength || value.Length == 0) return Result<Email>.Fail
        (
            DomainErrors.MaximumLength("email", MaxLength),
            ErrorType.Validation
        );

        var email = new Email(value);
        return Result<Email>.Ok(email);
    }
}