using Microsoft.AspNetCore.Mvc;
using System.Net;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Api.Abstractions;
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            var statusCode = result.SuccessType?.ToHttpStatusCode();

            return statusCode == HttpStatusCode.Created ? StatusCode((int)statusCode, result.Value) : Ok(result.Value);
        }

        var errorStatus = result.ErrorType.ToHttpStatusCode();
        return errorStatus switch
        {
            HttpStatusCode.BadRequest => BadRequest(new { message = result.Error }),
            HttpStatusCode.NotFound => NotFound(new { message = result.Error }),
            HttpStatusCode.Conflict => Conflict(new { message = result.Error }),
            HttpStatusCode.Unauthorized => Unauthorized(new { message = result.Error }),
            _ => StatusCode((int)HttpStatusCode.InternalServerError, new { })
        };
    }
}