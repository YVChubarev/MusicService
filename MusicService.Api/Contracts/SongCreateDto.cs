namespace MusicService.Api.Contracts
{
    /// <summary>
    /// DTO для создания песни.
    /// </summary>
    public record SongCreateDto
    {
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
        /// Текст песни.
        /// </summary>
        public string? Lyrics { get; init; }

        #endregion
    }
}
