using FluentValidation;
using MusicService.Api.Endpoints;
using MusicService.Api.Services;
using MusicService.Api.Services.BackgroundServices;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSingleton<IMusicCatalog, InMemoryMusicCatalog>();
builder.Services.AddHostedService<CatalogScannerService>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapSongs();

app.Run();
