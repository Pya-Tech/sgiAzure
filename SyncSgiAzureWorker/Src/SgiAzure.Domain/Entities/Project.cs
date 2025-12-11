using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class Project : IProject
    {
        public int CompanyId { get; set; }
        public int Validity { get; set; }
        public required string Contract { get; set; }
        public required string System { get; set; }
        public required string Description { get; set; }
    }
}
