using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
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

services.AddPersistenceLayer(configuration)
        .AddSecurityLayer(configuration)
        .AddApplicationLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CineHubDbContext>();
    db.Database.Migrate();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseRouting();
app.UseCors("Angular");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();