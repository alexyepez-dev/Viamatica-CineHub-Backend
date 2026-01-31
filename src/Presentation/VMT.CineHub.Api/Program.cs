using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VMT.CineHub.Api.Extension;
using VMT.CineHub.Application.Extension;
using VMT.CineHub.Middlewares.Middlewares;
using VMT.CineHub.Persistence.Database;
using VMT.CineHub.Persistence.Extension;
using VMT.CineHub.Security.Extension;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var jsonConvertEnum = new JsonStringEnumConverter();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors
        (
            options => options.AddPolicy("Angular", policy =>
            {
                policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            }
        ));

services.AddControllers()
        .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(jsonConvertEnum));

services.AddWebApiLayer()
        .AddPersistenceLayer(configuration)
        .AddSecurityLayer(configuration)
        .AddApplicationLayer();

services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrationsWithRetry();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseRouting();
app.UseCors("Angular");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();