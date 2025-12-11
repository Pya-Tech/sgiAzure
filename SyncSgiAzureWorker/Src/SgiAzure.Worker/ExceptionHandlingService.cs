namespace SgiAzure.Worker
{

    /// <summary>
    /// Clase encargada de gestionar todas las excepciones ocurridas de manera global en el aplicativo.
    /// </summary>
    public class ExceptionHandlingService : IHostedService
    {
        private readonly IHostedService _innerService;
        private readonly ILogger<ExceptionHandlingService> _logger;

        public ExceptionHandlingService(IHostedService innerService, ILogger<ExceptionHandlingService> logger)
        {
            _innerService = innerService;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _innerService.StartAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while starting the service.");
                throw;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _innerService.StopAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while stopping the service.");
                throw;
            }
        }
    }
}