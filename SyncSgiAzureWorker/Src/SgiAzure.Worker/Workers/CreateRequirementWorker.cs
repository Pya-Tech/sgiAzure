using Infrastructure.Messaging.Interfaces;
using SgiAzure.Application.Dtos;
using SgiAzure.Infrastructure.Messaging;

namespace SgiAzure.Worker.Workers
{
    public class CreateRequirementWorker : BackgroundService
    {
        private readonly IMessageBroker _messageBroker;

        private readonly IServiceScopeFactory _scopeFactory;

        private readonly ILogger<CreateRequirementWorker> _logger;

        private readonly string _queueName;

        public CreateRequirementWorker(
            IMessageBroker messageBroker,
            IServiceScopeFactory scopeFactory,
            ILogger<CreateRequirementWorker> logger)
        {
            _messageBroker = messageBroker;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _queueName = "WorkItemInsert";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Iniciando CreateRequirementWorker. Escuchando cola {QueueName}",
                _queueName);

            return _messageBroker.SubscribeAsync(
                _queueName,
                HandleMessageAsync,
                stoppingToken);
        }

        /// <summary>
        /// Se ejecuta por cada mensaje recibido
        /// </summary>
        private async Task HandleMessageAsync(
            string rawMessage,
            IMessageMetadata metadata,
            CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();

            var pipeline = scope.ServiceProvider
                .GetRequiredService<MessagePipeline<WorkitemCreatedMessageDto>>();

            await pipeline.ProcessAsync(rawMessage, metadata, ct);
        }
    }
}
