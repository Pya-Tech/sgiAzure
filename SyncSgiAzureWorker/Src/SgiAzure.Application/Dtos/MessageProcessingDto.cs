using SgiAzure.Application.Interfaces.Dtos;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Application.Dtos
{
    public class MessageProcessingDto : IMessageProcesingDto
    {
        public int? Id { get; set; }
        public string? MessageId { get; set; }
        public required string Queue { get; set; }
        public int? RequirementId { get; set; }
        public int? WorkItemId { get; set; }
        public MessageProcessingStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public int Attempts { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RequirementWorkItemId { get; set; }

        public MessageProcessing ToDomainEntity()
        {
            return new()
            {
                MessageId = this.MessageId ?? string.Empty,
                Queue = this.Queue,
                Attempts = this.Attempts,
                CreatedAt = this.CreatedAt,
                ErrorMessage = this.ErrorMessage,
                RequirementId = this.RequirementId,
                WorkItemId = this.WorkItemId,
                Status = this.Status,
                RequirementWorkItemId = this.RequirementWorkItemId
            };
        }

        public static MessageProcessingDto FromDomainEntity(MessageProcessing messageProcessing)
        {
            return new MessageProcessingDto()
            {
                Id = messageProcessing.Id,
                MessageId = messageProcessing.MessageId,
                Queue = messageProcessing.Queue,
                RequirementId = messageProcessing.RequirementId,
                WorkItemId = messageProcessing.WorkItemId,
                Status = messageProcessing.Status,
                ErrorMessage = messageProcessing.ErrorMessage,
                Attempts = messageProcessing.Attempts,
                CreatedAt = messageProcessing.CreatedAt,
                RequirementWorkItemId = messageProcessing.RequirementWorkItemId
            };
        }
    }
}
