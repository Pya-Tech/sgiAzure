namespace SgiAzure.Domain.Interfaces.Entities
{
    public interface IProject
    {
        /// <summary>
        /// Unique identifier for the company.
        /// </summary>
        int CompanyId { get; set; }

        /// <summary>
        /// Project validity period.
        /// </summary>
        int Validity { get; set; }

        /// <summary>
        /// Contract associated with the project.
        /// </summary>
        string Contract { get; set; }

        /// <summary>
        /// System related to the project.
        /// </summary>
        string System { get; set; }

        /// <summary>
        /// Detailed description of the project.
        /// </summary>
        string Description { get; set; }
    }
}