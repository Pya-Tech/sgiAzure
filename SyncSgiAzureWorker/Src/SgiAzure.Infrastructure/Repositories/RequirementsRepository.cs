using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.Sgi;

namespace Src.SgiAzure.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio que implementa las operaciones CRUD para la entidad <see cref="Requirement"/>.
    /// Utiliza <see cref="SgiDbContext"/> para interactuar con la base de datos.
    /// </summary>
    public class RequirementsRepository : IRequirementRepository<Requirement>
    {
        private readonly SgiDbContext _context;

        public RequirementsRepository(SgiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea un nuevo requerimiento de forma asincrónica y lo guarda en la base de datos.
        /// </summary>
        /// <param name="requirement">Objeto con los datos del requerimiento a insertar.</param>
        /// <returns>El objeto <see cref="Requirement"/> creado.</returns>
        public async Task<Requirement> CreateAsync(Requirement requirement, CancellationToken ct = default)
        {
            var created = await _context.Requirements.AddAsync(requirement, ct);
            await _context.SaveChangesAsync(ct);
            return created.Entity;
        }

        /// <summary>
        /// Elimina un requerimiento de forma asincrónica por su identificador.
        /// </summary>
        /// <param name="id">El identificador del requerimiento a eliminar.</param>
        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var requirement = await _context.Requirements.FindAsync(id, ct);
            if (requirement == null)
                throw new SgiAzureException($"No existe requerimiento con el Id: {id}", ErrorCode.EntityNotFound);

            _context.Requirements.Remove(requirement);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Obtiene todos los requerimientos de forma asincrónica.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene un <see cref="IEnumerable{Requirement}"/>
        /// con todos los requerimientos.</returns>
        public async Task<IEnumerable<Requirement>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Requirements.ToListAsync(ct);
        }

        /// <summary>
        /// Obtiene un requerimiento por su identificador de forma asincrónica.
        /// </summary>
        /// <param name="id">Identificador único del requerimiento.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene el objeto <see cref="Requirement"/>
        /// asociado al identificador, o null si no se encuentra.</returns>
        public async Task<Requirement?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Requirements.FirstOrDefaultAsync(rw => rw.RequirementId == id, ct);
        }

        /// <summary>
        /// Actualiza un requerimiento existente de forma asincrónica.
        /// </summary>
        /// <param name="requirementId">El identificador del requerimiento a actualizar.</param>
        /// <param name="requirement">El objeto <see cref="Requirement"/> con los nuevos datos a actualizar.</param>
        public async Task UpdateAsync(int requirementId, Requirement requirement, CancellationToken ct = default)
        {
            var requirementFind = await _context.Requirements.FindAsync(requirementId, ct) ?? 
                throw new SgiAzureException($"No existe requerimiento con el Id: {requirementId}", ErrorCode.EntityNotFound);
            UpdateProperties(ref requirementFind, requirement);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Actualiza las propiedades del requerimiento, si son válidas.
        /// </summary>
        /// <param name="existing">El requerimiento existente que se va a actualizar.</param>
        /// <param name="updated">El requerimiento con los nuevos valores.</param>
        /// <summary>
        private void UpdateProperties(ref Requirement existing, Requirement updated)
        {
            if (updated.ActualHours.HasValue) existing.ActualHours = updated.ActualHours;
            if (updated.AdditionalHours.HasValue) existing.AdditionalHours = updated.AdditionalHours;
            if (!string.IsNullOrEmpty(updated.Status)) existing.Status = updated.Status;
            if (!string.IsNullOrEmpty(updated.Stage)) existing.Stage = updated.Stage;
            if (!string.IsNullOrEmpty(updated.ReportedComment)) existing.ReportedComment = updated.ReportedComment;
            if (!string.IsNullOrEmpty(updated.ErrorDescription)) existing.ErrorDescription = updated.ErrorDescription;
            if (!string.IsNullOrEmpty(updated.Program)) existing.Program = updated.Program;
            if (updated.RelatedRequirementId.HasValue) existing.RelatedRequirementId = updated.RelatedRequirementId;
            if (!string.IsNullOrEmpty(updated.ProcessRequirementType)) existing.ProcessRequirementType = updated.ProcessRequirementType;
            if (updated.ScheduledHours.HasValue) existing.ScheduledHours = updated.ScheduledHours;
            if (updated.ScheduledDate.HasValue) existing.ScheduledDate = updated.ScheduledDate;
            if (updated.AdjustedDate.HasValue) existing.AdjustedDate = updated.AdjustedDate;
            if (!string.IsNullOrEmpty(updated.ResponseByUser)) existing.ResponseByUser = updated.ResponseByUser;
            if (!string.IsNullOrEmpty(updated.OfficialRequirementType)) existing.OfficialRequirementType = updated.OfficialRequirementType;
            if (updated.HoursPerDay.HasValue) existing.HoursPerDay = updated.HoursPerDay;
            if (updated.StartDate.HasValue) existing.StartDate = updated.StartDate;
            if (updated.Priority.HasValue) existing.Priority = updated.Priority;
            if (updated.SatisfactionLevel.HasValue) existing.SatisfactionLevel = updated.SatisfactionLevel;
            if (updated.TechnicalSatisfactionLevel.HasValue) existing.TechnicalSatisfactionLevel = updated.TechnicalSatisfactionLevel;
            if (updated.ServiceSatisfactionLevel.HasValue) existing.ServiceSatisfactionLevel = updated.ServiceSatisfactionLevel;
            if (updated.TimeSatisfactionLevel.HasValue) existing.TimeSatisfactionLevel = updated.TimeSatisfactionLevel;
            if (!string.IsNullOrEmpty(updated.ReportedRequirementType)) existing.ReportedRequirementType = updated.ReportedRequirementType;
            if (!string.IsNullOrEmpty(updated.Company)) existing.Company = updated.Company;
            if (!string.IsNullOrEmpty(updated.Project)) existing.Project = updated.Project;
            if (!string.IsNullOrEmpty(updated.Module)) existing.Module = updated.Module;
            if (!string.IsNullOrEmpty(updated.IsDisplaced)) existing.IsDisplaced = updated.IsDisplaced;
            if (!string.IsNullOrEmpty(updated.IsReprogrammed)) existing.IsReprogrammed = updated.IsReprogrammed;
            if (!string.IsNullOrEmpty(updated.AllowsHolidayScheduling)) existing.AllowsHolidayScheduling = updated.AllowsHolidayScheduling;
            if (updated.InitialScheduledDate.HasValue) existing.InitialScheduledDate = updated.InitialScheduledDate;
            if (!string.IsNullOrEmpty(updated.ProgrammedByUser)) existing.ProgrammedByUser = updated.ProgrammedByUser;
            if (!string.IsNullOrEmpty(updated.ResponsibleUser)) existing.ResponsibleUser = updated.ResponsibleUser;
            if (!string.IsNullOrEmpty(updated.AdditionalComment)) existing.AdditionalComment = updated.AdditionalComment;
            if (updated.InitialScheduledHours.HasValue) existing.InitialScheduledHours = updated.InitialScheduledHours;
            if (!string.IsNullOrEmpty(updated.IsIncidentReported)) existing.IsIncidentReported = updated.IsIncidentReported;
            if (!string.IsNullOrEmpty(updated.IsIncidentResolved)) existing.IsIncidentResolved = updated.IsIncidentResolved;
            if (updated.IncidentType.HasValue) existing.IncidentType = updated.IncidentType;
            if (!string.IsNullOrEmpty(updated.IncidentObservation)) existing.IncidentObservation = updated.IncidentObservation;
            if (!string.IsNullOrEmpty(updated.CorrectionId)) existing.CorrectionId = updated.CorrectionId;
            if (updated.Order.HasValue) existing.Order = updated.Order;
            if (updated.CategoryId.HasValue) existing.CategoryId = updated.CategoryId;
            if (updated.CategoryIdResponse.HasValue) existing.CategoryIdResponse = updated.CategoryIdResponse;
            if (updated.DeliveryDate.HasValue) existing.DeliveryDate = updated.DeliveryDate;
            if (updated.EndDate.HasValue) existing.EndDate = updated.EndDate;
            if (updated.ImpactLevel.HasValue) existing.ImpactLevel = updated.ImpactLevel;
            if (!string.IsNullOrEmpty(updated.Type)) existing.Type = updated.Type;
            if (updated.UrgencyLevel.HasValue) existing.UrgencyLevel = updated.UrgencyLevel;
            if (updated.ValidityPeriod.HasValue) existing.ValidityPeriod = updated.ValidityPeriod;
            if (!string.IsNullOrEmpty(updated.TechnicalSatisfactionComment)) existing.TechnicalSatisfactionComment = updated.TechnicalSatisfactionComment;
            if (!string.IsNullOrEmpty(updated.ServiceSatisfactionComment)) existing.ServiceSatisfactionComment = updated.ServiceSatisfactionComment;
            if (!string.IsNullOrEmpty(updated.TimeSatisfactionComment)) existing.TimeSatisfactionComment = updated.TimeSatisfactionComment;
            if (!string.IsNullOrEmpty(updated.Area)) existing.Area = updated.Area;
            if (!string.IsNullOrEmpty(updated.SubArea)) existing.SubArea = updated.SubArea;
            if (!string.IsNullOrEmpty(updated.RequerimientTypeClient)) existing.RequerimientTypeClient = updated.RequerimientTypeClient;
        }
    }
}