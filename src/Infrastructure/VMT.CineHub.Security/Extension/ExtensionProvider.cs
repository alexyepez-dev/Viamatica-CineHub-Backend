using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VMT.CineHub.Security.Configurations.Access;
using VMT.CineHub.Security.Configurations.Construction;
using VMT.CineHub.Security.Interfaces.Access;
using VMT.CineHub.Security.Interfaces.Construction;
using VMT.CineHub.Security.Models;

namespace VMT.CineHub.Security.Extension;
public static class ExtensionProvider
{
    public static IServiceCollection AddSecurityLayer
    (
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddScoped<ITokenConstruction, TokenConstruction>();
        services.AddScoped<IAccessToken, AccessToken>();

        return services;
    }
}