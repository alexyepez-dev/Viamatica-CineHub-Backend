using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using VMT.CineHub.Application.Interfaces.Authentication.Login;
using VMT.CineHub.Application.Interfaces.Authentication.Register;
using VMT.CineHub.Application.Interfaces.Mappers;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Application.Mappers;
using VMT.CineHub.Application.Modules.Authentication.Login;
using VMT.CineHub.Application.Modules.Authentication.Register;
using VMT.CineHub.Application.UseCases;

namespace VMT.CineHub.Application.Extension;
public static class ExtensionProvider
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<AssemblyReference>();

        services.AddScoped<IMapping, Mapping>();
        services.AddScoped<IRegisterMappingUseCase, RegisterMappingUseCase>();
        services.AddScoped<IHashingPasswordUseCase, HashingPasswordUseCase>();
        services.AddScoped<IVerifyHashinPasswordUseCase, VerifyHashinPasswordUseCase>();
        services.AddScoped<IRegisterCredentialsValidationUseCase, RegisterCredentialsValidationUseCase>();
        services.AddScoped<ILoginCredentialsValidationUseCase, LoginCredentialsValidationUseCase>();

        services.AddTransient<ILoginCommandHandler, LoginCommandHandler>();
        services.AddTransient<IRegisterCommandHandler, RegisterCommandHandler>();

        return services;
    }
}