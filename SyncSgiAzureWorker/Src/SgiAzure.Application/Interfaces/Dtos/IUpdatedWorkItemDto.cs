using SgiAzure.Application.Dtos;

namespace SgiAzure.Application.Interfaces.Dtos
{
    public interface IUpdatedWorkItemDto
    {
        public WorkItemDto OldWorkItem { get; set; }

        public WorkItemDto NewWorkItem { get; set; }
    }
}
