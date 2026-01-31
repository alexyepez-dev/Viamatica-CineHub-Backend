using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Api.Extension;

public static class ExtensionProvider
{
    public static IServiceCollection AddWebApiLayer(this IServiceCollection services)
    {
        services.AddSwaggerGen
        (
            x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CineHub API",
                    Description = "Administración de películas y salas de cine."
                });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese un token válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            }
        );

        return services;
    }

    public static void ApplyMigrationsWithRetry(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CineHubDbContext>();
        var strategy = db.Database.CreateExecutionStrategy();

        strategy.Execute(() => db.Database.Migrate());
    }
}