using Microsoft.Extensions.Configuration;
using Serilog;

namespace VMT.CineHub.Middlewares.Serilog;

public static class SerilogConfiguration
{
    public static void UseLoggerConfiguration(IConfigurationManager configuration)
    {
        Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
    }
}