using MusicService.Api.Contracts;
using MusicService.Api.Filters;
using MusicService.Api.Mappings;
using MusicService.Api.Models;
using MusicService.Api.Services;

namespace MusicService.Api.Endpoints
{
    /// <summary>
    /// Всё связанное с песнями.
    /// </summary>
    public static class SongsEndpoints
    {
        /// <summary>
        /// /songs
        /// </summary>
        public static RouteGroupBuilder MapSongs(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/songs");

            group.MapGet("/", GetSongs);
            group.MapGet("/{id:guid}", GetSong);
            group.MapPost("/", PostSong).AddEndpointFilter<ValidationFilter<SongCreateDto>>();
            group.MapDelete("/{id:guid}", DeleteSong);

            return group;
        }

        private static async Task<IResult> GetSongs(IMusicCatalog catalog, CancellationToken ct) => Results.Ok(await catalog.GetAllAsync(ct));

        private static async Task<IResult> GetSong(Guid id, IMusicCatalog catalog, CancellationToken ct)
        {
            var song = await catalog.GetAsync(id, ct);
            if (song is null) return Results.NotFound();
            return Results.Ok(song);
        }

        private static async Task<IResult> PostSong(SongCreateDto dto, IMusicCatalog catalog, CancellationToken ct, ILogger<Program> logger)
        {
            Song song = dto.ToDomain();
            await catalog.AddAsync(song, ct);
            logger.LogInformation("Song {SongId} added.", song.Id);
            return Results.Created($"/songs/{song.Id}", song);
        }

        private static async Task<IResult> DeleteSong(Guid id, IMusicCatalog catalog, CancellationToken ct, ILogger<Program> logger)
        {
            if (!await catalog.DeleteAsync(id, ct)) return Results.NotFound();
            logger.LogInformation("Song {SongId} deleted.", id);
            return Results.NoContent();
        }
    }
}
