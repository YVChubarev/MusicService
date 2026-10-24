namespace MusicService.Api.Services.BackgroundServices
{
    /// <summary>
    /// Имитация периодического анализа
    /// <param name="logger">Логгер.</param>
    /// </summary>
    public class CatalogScannerService(ILogger<CatalogScannerService> logger) : BackgroundService
    {
        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(5000, stoppingToken);
                    logger.LogDebug("Catalog scanned.");
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
    }
}
