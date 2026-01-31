using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using VMT.CineHub.Application.Interfaces.Authentication.Login;
using VMT.CineHub.Application.Interfaces.Authentication.Register;
using VMT.CineHub.Application.Interfaces.Dashboard;
using VMT.CineHub.Application.Interfaces.Mappers;
using VMT.CineHub.Application.Interfaces.MovieImages.AssignImageToMovie;
using VMT.CineHub.Application.Interfaces.MovieMovieTheaters.AssignMovieToMovieTheater;
using VMT.CineHub.Application.Interfaces.Movies.CreateMovie;
using VMT.CineHub.Application.Interfaces.Movies.DeleteMovie;
using VMT.CineHub.Application.Interfaces.Movies.GetAllMovies;
using VMT.CineHub.Application.Interfaces.Movies.GetMovieBySlug;
using VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByDate;
using VMT.CineHub.Application.Interfaces.Movies.SearchMoviesByName;
using VMT.CineHub.Application.Interfaces.Movies.UpdateMovie;
using VMT.CineHub.Application.Interfaces.MovieTheaters.CreateMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.DeleteMovieTheater;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Application.Interfaces.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Application.Interfaces.MovieTheaters.UpdateMovieTheater;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Application.Mappers;
using VMT.CineHub.Application.Modules.Authentication.Login;
using VMT.CineHub.Application.Modules.Authentication.Register;
using VMT.CineHub.Application.Modules.Dashboard;
using VMT.CineHub.Application.Modules.MovieImages.AssignImageToMovie;
using VMT.CineHub.Application.Modules.MovieMovieTheaters.AssignMovieToMovieTheater;
using VMT.CineHub.Application.Modules.Movies.CreateMovie;
using VMT.CineHub.Application.Modules.Movies.DeleteMovie;
using VMT.CineHub.Application.Modules.Movies.GetAllMovies;
using VMT.CineHub.Application.Modules.Movies.GetMovieBySlug;
using VMT.CineHub.Application.Modules.Movies.SearchMoviesByDate;
using VMT.CineHub.Application.Modules.Movies.SearchMoviesByName;
using VMT.CineHub.Application.Modules.Movies.UpdateMovie;
using VMT.CineHub.Application.Modules.MovieTheaters.CreateMovieTheater;
using VMT.CineHub.Application.Modules.MovieTheaters.DeleteMovieTheater;
using VMT.CineHub.Application.Modules.MovieTheaters.GetAllMovieTheaters;
using VMT.CineHub.Application.Modules.MovieTheaters.GetMoviesTheaterStatus;
using VMT.CineHub.Application.Modules.MovieTheaters.UpdateMovieTheater;
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
        services.AddScoped<IValidateDateUseCase, ValidateDateUseCase>();

        services.AddTransient<ILoginCommandHandler, LoginCommandHandler>();
        services.AddTransient<IRegisterCommandHandler, RegisterCommandHandler>();
        services.AddTransient<ICreateMovieCommandHandler, CreateMovieCommandHandler>();
        services.AddTransient<ISearchMoviesByNameQueryHandler, SearchMoviesByNameQueryHandler>();
        services.AddTransient<IUpdateMovieCommandHandler, UpdateMovieCommandHandler>();
        services.AddTransient<IDeleteMovieCommandHandler, DeleteMovieCommandHandler>();
        services.AddTransient<ISearchMoviesByDateQueryHandler, SearchMoviesByDateQueryHandler>();
        services.AddTransient<IGetMoviesTheaterStatusQueryHandler, GetMoviesTheaterStatusQueryHandler>();
        services.AddTransient<IGetDashboardQueryHandler, GetDashboardQueryHandler>();
        services.AddTransient<IGetAllMoviesQueryHandler, GetAllMoviesQueryHandler>();
        services.AddTransient<IAssignImageToMovieCommandHandler, AssignImageToMovieCommandHandler>();
        services.AddTransient<IGetAllMovieTheatersQueryHandler, GetAllMovieTheatersQueryHandler>();
        services.AddTransient<IGetMovieBySlugQueryHandler, GetMovieBySlugQueryHandler>();
        services.AddTransient<ICreateMovieTheaterCommandHandler, CreateMovieTheaterCommandHandler>();
        services.AddTransient<IUpdateMovieTheaterCommandHandler, UpdateMovieTheaterCommandHandler>();
        services.AddTransient<IDeleteMovieTheaterCommandHandler, DeleteMovieTheaterCommandHandler>();
        services.AddTransient<IAssignMovieToMovieTheaterCommandHandler, AssignMovieToMovieTheaterCommandHandler>();

        return services;
    }
}