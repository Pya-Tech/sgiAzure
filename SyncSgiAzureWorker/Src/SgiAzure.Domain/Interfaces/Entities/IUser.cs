namespace SgiAzure.Domain.Entities
{
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the UserSystem (User in Oracle).
        /// </summary>
        string UserSystem { get; set; }

        /// <summary>
        /// Gets or sets the user's IdCard (identification number).
        /// </summary>
        long IdCard { get; set; }

        /// <summary>
        /// Gets or sets the user's FirstName (first name of the user).
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's Dependency (department or group the user belongs to).
        /// </summary>
        string? Dependency { get; set; }

        /// <summary>
        /// Gets or sets the user's Position (job title of the user).
        /// </summary>
        string? Position { get; set; }

        /// <summary>
        /// Gets or sets the Zone (area the user belongs to, nullable).
        /// </summary>
        int? Zone { get; set; }

        /// <summary>
        /// Gets or sets the Printer path for the user's primary printer.
        /// </summary>
        string? Printer { get; set; }

        /// <summary>
        /// Gets or sets the Status (active or inactive status of the user).
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// Gets or sets the MaxSessions (maximum number of sessions allowed for the user).
        /// </summary>
        int? MaxSessions { get; set; }

        /// <summary>
        /// Gets or sets the user's Email address.
        /// </summary>
        string? Email { get; set; }

        /// <summary>
        /// Gets or sets the path to the Auxiliary Printer.
        /// </summary>
        string? AuxiliaryPrinter { get; set; }

        /// <summary>
        /// Gets or sets the MobilePhone (cellphone number of the user).
        /// </summary>
        long? MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the SupervisorUser (the supervisor's system user).
        /// </summary>
        string? SupervisorUser { get; set; }

        /// <summary>
        /// Gets or sets the IdCardIssuedCity (city or municipality where the ID card was issued).
        /// </summary>
        string? IdCardIssuedCity { get; set; }

        /// <summary>
        /// Gets or sets the Password (encrypted password of the user).
        /// </summary>
        string? Password { get; set; }

        /// <summary>
        /// Gets or sets the UserType (defines if user is from database, application, or active directory).
        /// </summary>
        string? UserType { get; set; }

        /// <summary>
        /// Gets or sets the DeactivationDate (date when the user was deactivated).
        /// </summary>
        DateTime? DeactivationDate { get; set; }

        /// <summary>
        /// Gets or sets the ProfilePicture (photo of the user in byte array format).
        /// </summary>
        byte[]? ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the Office (the office where the user is assigned).
        /// </summary>
        string Office { get; set; }

        /// <summary>
        /// Gets or sets the Extension (telephone extension of the user).
        /// </summary>
        int? Extension { get; set; }

        /// <summary>
        /// Gets or sets the CreationDate (date when the user was created).
        /// </summary>
        DateTime? CreationDate { get; set; }

    }
}
