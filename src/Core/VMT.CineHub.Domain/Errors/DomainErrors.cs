namespace VMT.CineHub.Domain.Errors;
internal class DomainErrors
{
    public static string FielRequired(string field) => $"We're sorry, {field} is required.";
    public static string MaximumLength(string field, int length) => $"We're sorry, {field} must have length of ${length}.";
    public static string OnlyNumbers(string field) => $"We're sorry, {field} must contain only numbers.";
}