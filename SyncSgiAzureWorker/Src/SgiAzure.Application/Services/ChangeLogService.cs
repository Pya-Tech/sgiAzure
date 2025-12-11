using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Repositories;
using System.Text.Json;

namespace SgiAzure.Application.Services
{
    public class ChangeLogService : IChangeLogService
    {
        private readonly IChangelogRepository<Changelog> _changelogRepository;

        public ChangeLogService(IChangelogRepository<Changelog> changelogRepository) {
            _changelogRepository = changelogRepository;
        }

        public async Task DeleteAsync(int changeLogId, CancellationToken ct = default)
        {
            await _changelogRepository.DeleteAsync(changeLogId, ct);
        }

        public async Task RegisterChangeLog<T>(
            T changeValuesObject, 
            int requirementWorkItemId, 
            string origin, 
            ChangeType changeType = ChangeType.Created, CancellationToken ct = default)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(origin));
            ArgumentException.ThrowIfNullOrEmpty(nameof(changeValuesObject));
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true
            };
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(changeValuesObject, jsonSerializerOptions);
            string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);
            Changelog changelog = new()
            {
                Origin = origin,
                ChangeAt = DateTime.UtcNow,
                ChangeType = changeType,
                ChangeDescription = jsonString,
                RequirementWorkItemId = requirementWorkItemId
            };

            await _changelogRepository.AddAsync(changelog, ct);
        }

    }
}
