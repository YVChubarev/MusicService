using Microsoft.AspNetCore.Mvc;
using MusicService.Api.Contracts;
using MusicService.Api.Mappings;
using MusicService.Api.Middlewares;
using MusicService.Api.Models;
using MusicService.Api.Services;
using MusicService.Api.Services.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMusicCatalog, InMemoryMusicCatalog>();
builder.Services.AddHostedService<CatalogScannerService>();

var app = builder.Build();

app.UseMiddleware<RequestTimingMiddleware>();

app.MapGet("/songs", async (IMusicCatalog catalog, CancellationToken ct) => await catalog.GetAllAsync(ct));

app.MapGet("/songs/{id:guid}", async ([FromRoute] Guid id, IMusicCatalog catalog, CancellationToken ct) =>
{
    var song = await catalog.GetAsync(id, ct);
    if (song is null) return Results.NotFound();
    return Results.Ok(song);
});

app.MapPost("/songs", async ([FromBody] SongCreateDto dto, IMusicCatalog catalog, CancellationToken ct, ILogger<Program> logger) =>
{
    if (string.IsNullOrWhiteSpace(dto.Title)) return Results.BadRequest($"{nameof(dto.Title)} is required.");
    Song song = dto.ToDomain();
    await catalog.AddAsync(song, ct);
    logger.LogInformation("Song {SongId} added.", song.Id);
    return Results.Created($"/songs/{song.Id}", song);
});

app.MapDelete("/songs/{id:guid}", async ([FromRoute] Guid id, IMusicCatalog catalog, CancellationToken ct, ILogger<Program> logger) =>
{
    if (!await catalog.DeleteAsync(id, ct)) return Results.NotFound();
    logger.LogInformation("Song {SongId} deleted.", id);
    return Results.NoContent();
});

app.Run();
