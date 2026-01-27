using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Persistence.Extension;
public static class ExtensionProvider
{
    public static IServiceCollection AddPersistenceLayer
    (
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.AddDbContext<CineHubDbContext>(x => x.UseSqlServer(configuration["ConnectionStrings:SqlServer"]));
        services.AddScoped(typeof(IRepository<>));

        return services;
    }
}