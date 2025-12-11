using Infrastructure.Messaging.Interfaces;
using SgiAzure.Application.Dtos;
using SgiAzure.Infrastructure.Messaging;

namespace SgiAzure.Worker.Workers
{
    public class UpdateRequirementWorker : BackgroundService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<UpdateRequirementWorker> _logger;
        private readonly string _queueName;

        public UpdateRequirementWorker(
            IMessageBroker messageBroker,
            IServiceScopeFactory scopeFactory,
            ILogger<UpdateRequirementWorker> logger)
        {
            _messageBroker = messageBroker;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _queueName = "WorkItemUpdate";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Iniciando UpdateRequirementWorker. Escuchando cola {Queue}",
                _queueName);

            return _messageBroker.SubscribeAsync(
                _queueName,
                HandleMessageAsync,
                stoppingToken);
        }

        private async Task HandleMessageAsync(string rawMessage, IMessageMetadata metadata, CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();

            var pipeline = scope.ServiceProvider.GetRequiredService<MessagePipeline<RequirementUpdatedDto>>();

            await pipeline.ProcessAsync(rawMessage, metadata, ct);
        }
    }
}
