using MusicService.Api.Contracts;
using MusicService.Api.Models;

namespace MusicService.Api.Mappings
{
    /// <summary>
    /// Сборник методов приведения типов к <see cref="Song"/>.
    /// </summary>
    public static class SongMappings
    {
        /// <summary>
        /// Преобразует <see cref="SongCreateDto"/> в <see cref="Song"/>.
        /// </summary>
        /// <param name="dto">Исходный тип.</param>
        public static Song ToDomain(this SongCreateDto dto) => new()
        {
            Title = dto.Title,
            Album = dto.Album,
            MainArtists = dto.MainArtists,
            FeaturingArtists = dto.FeaturingArtists,
            Genres = dto.Genres,
            ReleaseDate = dto.ReleaseDate,
            TrackNumber = dto.TrackNumber,
            AudioStreamUrl = dto.AudioStreamUrl,
            CoverUrl = dto.CoverUrl,
            VideoUrl = dto.VideoUrl,
            // потом добавить конвертер для записи или в PlainTextLyrics или в SyncedLyrics
            PlainTextLyrics = dto.Lyrics,
            // потом реализовать расчет Duration и AudioQuality
        };
    }
}
