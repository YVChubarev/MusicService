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
            logger.LogInformation("Started.");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(5000, stoppingToken);
                    logger.LogDebug("Catalog scanned.");
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogWarning("Completed with {Exception}: {Message}.", ex.GetType().Name, ex.Message);
                }
            }
            logger.LogInformation("Stopped.");
        }
    }
}
