using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Services
{
    public class MessageProcessingService : IMessageProcessingService<MessageProcessingDto>
    {
        private readonly IMessageProcessingRepository<MessageProcessing> _messageProcessingRepository;

        public MessageProcessingService(IMessageProcessingRepository<MessageProcessing> messageProcessingRepository) {
            _messageProcessingRepository = messageProcessingRepository;
        }

        public async Task RegisterMessage(MessageProcessingDto messageProcessingDto)
        {
            await _messageProcessingRepository.AddAsync(messageProcessingDto.ToDomainEntity());
        }

        public async Task DeleteAsync(string messageId)
        {
            await _messageProcessingRepository.DeleteAsync(messageId);
        }

        public async Task<MessageProcessingDto?> GetByMessageIdAsync(string messageId)
        {
            var messageProcessing = await _messageProcessingRepository.GetByMessageIdAsync(messageId);
            return MessageProcessingDto.FromDomainEntity(messageProcessing);
        }

        public Task<IEnumerable<MessageProcessingDto>> GetByStatusAsync(MessageProcessingStatus status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MessageProcessingDto messageProcessingDto)
        {
            throw new NotImplementedException();
        }
    }
}
