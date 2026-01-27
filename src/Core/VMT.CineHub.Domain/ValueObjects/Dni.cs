using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Errors;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Domain.ValueObjects;
public sealed class Dni
{
    public string Value { get; private set; }

    private Dni(string value) => Value = value;

    public const int MaxLength = 10;

    public static Result<Dni> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return Result<Dni>.Fail
        (
            DomainErrors.FielRequired("dni"),
            ErrorType.Validation
        );

        if (value.Length != MaxLength) return Result<Dni>.Fail
        (
            DomainErrors.MaximumLength("dni", MaxLength),
            ErrorType.Validation
        );

        if (!value.All(char.IsDigit)) return Result<Dni>.Fail
        (
            DomainErrors.OnlyNumbers("dni"),
            ErrorType.Validation
        );

        var dni = new Dni(value);
        return Result<Dni>.Ok(dni);
    }
}