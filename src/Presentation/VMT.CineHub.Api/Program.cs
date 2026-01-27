using VMT.CineHub.Application.Extension;
using VMT.CineHub.Persistence.Extension;
using VMT.CineHub.Security.Extension;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();
services.AddPersistenceLayer(configuration)
        .AddSecurityLayer(configuration)
        .AddApplicationLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();