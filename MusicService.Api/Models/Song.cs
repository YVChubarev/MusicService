namespace MusicService.Api.Models
{
    /// <summary>
    /// Структура песни.
    /// </summary>
    public record Song
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; init; } = Guid.NewGuid();

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; init; } = string.Empty;

        #region Связи (пока как строки, потом станут сущностями)

        /// <summary>
        /// Альбом.
        /// </summary>
        public string Album { get; init; } = string.Empty;

        /// <summary>
        /// Исполнители.
        /// </summary>
        public IEnumerable<string> MainArtists { get; init; } = [];

        /// <summary>
        /// Соисполнители.
        /// </summary>
        public IEnumerable<string> FeaturingArtists { get; init; } = [];

        /// <summary>
        /// Жанры.
        /// </summary>
        public IEnumerable<string> Genres { get; init; } = [];

        #endregion

        #region Метаданные

        /// <summary>
        /// Дата релиза.
        /// </summary>
        public DateOnly ReleaseDate { get; init; }

        /// <summary>
        /// Номер. Может быть <c>null</c> если это сингл.
        /// </summary>
        public int? TrackNumber { get; init; }

        /// <summary>
        /// Продолжительность.
        /// </summary>
        public TimeSpan Duration { get; init; }

        /// <summary>
        /// Качество аудиозаписи.
        /// </summary>
        public string AudioQuality { get; init; } = string.Empty;

        #endregion

        #region Медиа (ссылки)

        /// <summary>
        /// Ссылка на аудиодорожку.
        /// </summary>
        public string AudioStreamUrl { get; init; } = string.Empty;

        /// <summary>
        /// Ссылка на обложку. Может быть <c>null</c> если обложка отсутствует.
        /// </summary>
        public string? CoverUrl { get; init; }

        /// <summary>
        /// Ссылка на клип. Может быть <c>null</c> если клип отсутствует.
        /// </summary>
        public string? VideoUrl { get; init; }

        #endregion

        #region Тексты

        /// <summary>
        /// Простой текст песни.
        /// </summary>
        public string? PlainTextLyrics { get; init; }

        /// <summary>
        /// LRC формат для караоке.
        /// </summary>
        public string? SyncedLyrics { get; init; }

        #endregion
    }
}
