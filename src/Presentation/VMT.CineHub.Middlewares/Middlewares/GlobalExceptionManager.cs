using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using VMT.CineHub.Middlewares.Constants;

namespace VMT.CineHub.Middlewares.Middlewares;

public sealed class GlobalExceptionMiddleware
(
    RequestDelegate next,
    ILogger<GlobalExceptionMiddleware> logger
)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var response = new ErrorResponse
        (
            context.Response.StatusCode,
            "We're sorry, occurred error server.",
            exception.Message
        );

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
