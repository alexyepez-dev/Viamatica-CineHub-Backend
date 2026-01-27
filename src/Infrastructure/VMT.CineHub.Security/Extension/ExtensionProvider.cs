using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer
                (
                    x => x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JwtSettings:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    }
                );

        return services;
    }
}