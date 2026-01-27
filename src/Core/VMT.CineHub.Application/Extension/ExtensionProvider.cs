using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using VMT.CineHub.Application.Interfaces.Authentication.Login;

namespace VMT.CineHub.Application.Extension;
public static class ExtensionProvider
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<AssemblyReference>();

        services.AddTransient<ILoginCommandHandler>();

        return services;
    }
}