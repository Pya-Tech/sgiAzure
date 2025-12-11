using Infrastructure.Messaging.Interfaces;

namespace Infrastructure.Messaging.Models
{
    public class MessageMetadata : IMessageMetadata
    {
        public string? MessageId { get; set; }
        public required string Exchange { get; set; }
        public required string RoutingKey { get; set; }
        public ulong DeliveryTag { get; set; }
        public IDictionary<string, object?>? Headers { get; set; }
        public required string Queue { get; set; }
        public int Attempt { get; set; }
    }
}