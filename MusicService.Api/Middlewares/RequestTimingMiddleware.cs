using System.Diagnostics;

namespace MusicService.Api.Middlewares
{
    /// <summary>
    /// Логирует время выполнения запроса.
    /// </summary>
    /// <param name="next">Делегат.</param>
    /// <param name="logger">Логгер.</param>
    public class RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {

        /// <summary>
        /// Асинхронно выполняет запрос через делегат, гогируя время выполнения.
        /// </summary>
        /// <param name="context">Запрос.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();
            logger.LogInformation("Request to {Method} {Path} took {Elapsed} ms.",
                                  context.Request.Method,
                                  context.Request.Path,
                                  stopwatch.ElapsedMilliseconds);
        }
    }
}
