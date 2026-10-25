using MusicService.Api.Models;

namespace MusicService.Api.Services
{
    /// <summary>
    /// Интерфейс каталога музыки.
    /// </summary>
    public interface IMusicCatalog
    {
        /// <summary>
        /// Возвращает все песни.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// 
        Task<IEnumerable<Song>> GetAllAsync(CancellationToken token = default);

        /// <summary>
        /// Возвращает песню с соответствующим идентификатором или <c>null</c> если такой нет.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="token">Токен отмены.</param>
        Task<Song?> GetAsync(Guid id,  CancellationToken token = default);

        /// <summary>
        /// Добавляет песню в сервис.
        /// </summary>
        /// <param name="song">Объект для добавления.</param>
        /// <param name="token">Токен отмены.</param>
        Task AddAsync(Song song, CancellationToken token = default);

        /// <summary>
        /// Удаляет песню из сервиса, если такая есть.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns><c>true</c> если песня удалена, иначе <c>false</c>.</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken token = default);
    }
}
