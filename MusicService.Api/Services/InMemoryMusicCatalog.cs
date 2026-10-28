using MusicService.Api.Models;
using System.Collections.Concurrent;

namespace MusicService.Api.Services
{
    /// <summary>
    /// Каталог музыки, все в памяти.
    /// </summary>
    public class InMemoryMusicCatalog : IMusicCatalog
    {
        private readonly ConcurrentDictionary<Guid, Song> _songs = new();

        /// <summary>
        /// Каталог музыки, все в памяти.
        /// </summary>
        public InMemoryMusicCatalog()
        {
            Guid id = new(0,0,0,0,0,0,0,0,0,0,1);
            _songs[id] = new()
            {
                Id = id,
                Title = "Song 2",
                MainArtists = ["Blur"],
                Genres = ["Rock"],
                AudioStreamUrl = "data/audio/Позови меня с собой.mp3",
            };
            id = new(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
            _songs[id] = new()
            {
                Id = id,
                Title = "Rapsody",
                MainArtists = ["Queen"],
                Genres = ["Rock"],
                AudioStreamUrl = "data/audio/Три полоски.mp3",
            };
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Song>> GetAllAsync(CancellationToken token = default) =>
            Task.FromResult(_songs.Values.AsEnumerable());

        /// <inheritdoc/>
        public Task<Song?> GetAsync(Guid id, CancellationToken token = default) =>
            Task.FromResult(_songs.TryGetValue(id, out var song) ? song : null);

        /// <inheritdoc/>
        public Task AddAsync(Song song, CancellationToken token = default)
        {
            _songs[song.Id] = song;
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task<bool> DeleteAsync(Guid id, CancellationToken token = default) =>
            Task.FromResult(_songs.Remove(id, out _));
    }
}
