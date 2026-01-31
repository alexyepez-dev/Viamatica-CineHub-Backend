using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Persistence.Database;
using VMT.CineHub.Persistence.Repositories;

namespace VMT.CineHub.Persistence.Extension;
public static class ExtensionProvider
{
    public static IServiceCollection AddPersistenceLayer
    (
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.AddDbContext<CineHubDbContext>
        (
            x => x.UseSqlServer
            (
                configuration["ConnectionStrings:SqlServer"],
                opt => opt.EnableRetryOnFailure
                (
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                )
            )
        );
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}