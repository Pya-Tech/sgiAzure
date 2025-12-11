using Infrastructure.Messaging.Interfaces;
using SgiAzure.Application.Dtos;
using SgiAzure.Infrastructure.Messaging;

namespace SgiAzure.Worker.Workers
{
    public class UpdateWorkItemWorker : BackgroundService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<UpdateWorkItemWorker> _logger;
        private readonly string _queueName;

        public UpdateWorkItemWorker(
            IMessageBroker messageBroker,
            IServiceScopeFactory scopeFactory,
            ILogger<UpdateWorkItemWorker> logger)
        {
            _messageBroker = messageBroker;
            _scopeFactory = scopeFactory;
            _logger = logger;

            _queueName = "SgiUpdate";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Iniciando UpdateWorkItemWorker. Escuchando cola {QueueName}",
                _queueName);

            return _messageBroker.SubscribeAsync(
                _queueName,
                HandleMessageAsync,
                stoppingToken
            );
        }

        private async Task HandleMessageAsync(
            string rawMessage,
            IMessageMetadata metadata,
            CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();

            var pipeline = scope.ServiceProvider
                .GetRequiredService<MessagePipeline<RequirementUpdatedDto>>();

            await pipeline.ProcessAsync(rawMessage, metadata, ct);
        }
    }
}
