using System.Net;
using VMT.CineHub.Domain.Enums;

namespace VMT.CineHub.Api.Abstractions;
public static class Extensions
{
    public static HttpStatusCode ToHttpStatusCode(this SuccessType successType) =>
        successType switch
        {
            SuccessType.Created => HttpStatusCode.Created,
            _ => HttpStatusCode.OK
        };

    public static HttpStatusCode ToHttpStatusCode(this ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => HttpStatusCode.BadRequest,
            ErrorType.NotFound => HttpStatusCode.NotFound,
            ErrorType.Conflict => HttpStatusCode.Conflict,
            ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError
        };
}