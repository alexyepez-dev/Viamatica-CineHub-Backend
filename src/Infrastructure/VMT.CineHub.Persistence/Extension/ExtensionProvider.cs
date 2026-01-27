using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Persistence.Extension;
public static class ExtensionProvider
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<CineHubDbContext>(x => x.UseSqlServer("ConnectionStrings:SqlServer"));
        services.AddScoped(typeof(IRepository<>));

        return services;
    }
}