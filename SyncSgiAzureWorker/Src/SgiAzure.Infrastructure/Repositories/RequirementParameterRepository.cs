using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.Sgi;

namespace SgiAzure.Infrastructure.Repositories
{
    public class RequirementParameterRepository : IRequirementParameterRepository<Multitable>
    {
        /// <summary>
        /// Inyección de dependencias del contexto de la base de datos.
        /// </summary>
        private readonly SgiDbContext _context;

        public RequirementParameterRepository(SgiDbContext context)
        {
            _context = context;
        }

        public async Task<Multitable> GetRequirementAreaByIdAsync(string areaId, string company, CancellationToken ct = default)
        {
            var requirementArea = await _context.Multitables
                .Where<Multitable>((multitable) => multitable.TableName == $"REQ_AREAS_{company}" && multitable.CodeId == areaId)
                .FirstOrDefaultAsync(ct);

            return requirementArea ?? throw new SgiAzureException($"No existe tipo de clasificación con id {areaId}", ErrorCode.EntityNotFound);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementAreas(string company, CancellationToken ct = default)
        {
            if (company == null) throw new ArgumentNullException(company);
            return await _context.Multitables.Where(multitable => multitable.TableName == $"REQ_AREAS_{company}").ToListAsync(ct);
        }

        public async Task<Multitable> GetRequirementClasificationByIdAsync(string clasificationId, string company, CancellationToken ct = default)
        {
            var requirementClasification = await _context.Multitables
                .Where<Multitable>((multitable) => multitable.TableName == $"REQ_TIPO_{company}" && multitable.CodeId == clasificationId)
                .FirstOrDefaultAsync(ct);
            return requirementClasification ?? throw new SgiAzureException($"No existe tipo de clasificación con id {clasificationId}", ErrorCode.EntityNotFound);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementClasifications(string company, CancellationToken ct = default)
        {
            if (company == null) throw new ArgumentNullException(company);
            return await _context.Multitables.Where(multitable => multitable.TableName == $"REQ_TIPO_{company}").ToListAsync(ct);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementContractsByCompany(string company, CancellationToken ct = default)
        {
            if(company == null) throw new ArgumentNullException(company);
            var contract = await _context.Multitables.Where(multitable => multitable.TableName == "REQ_CONTRATOS" && multitable.AuxiliaryCode == company && multitable.IsActive == "S").ToListAsync(ct);
            return contract;
        }

        public async Task<Multitable> GetRequirementContractById(string contractId, CancellationToken ct = default)
        {
            var requirementContract = await _context.Multitables
                .Where(multitable => multitable.TableName == "REQ_CONTRATOS" && multitable.CodeId == contractId)
                .FirstOrDefaultAsync(ct);

            return requirementContract ?? throw new SgiAzureException($"No existo contrato con id {contractId}", ErrorCode.EntityNotFound);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementContracts(CancellationToken ct = default)
        {
            return await _context.Multitables
                .Where((multitable) => multitable.TableName == "REQ_CONTRATOS" && multitable.IsActive == "S")
                .ToListAsync(ct);
        }

        public async Task<Multitable> GetRequirementSubAreaByIdAsync(string subAreaId, string company, CancellationToken ct = default)
        {
            var requirementSubArea = await _context.Multitables
                .Where<Multitable>((multitable) => multitable.TableName == $"REQ_SUBAREAS_{company}" && multitable.CodeId == subAreaId)
                .FirstOrDefaultAsync(ct);

            return requirementSubArea ?? throw new SgiAzureException($"No existe tipo de clasificación con id {subAreaId}", ErrorCode.EntityNotFound);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementSubAreas(string company, CancellationToken ct = default)
        {
            if (company == null) throw new ArgumentNullException(company);
            return await _context.Multitables.Where(multitable => multitable.TableName == $"REQ_SUBAREAS_{company}" && multitable.IsActive == "S").ToListAsync(ct);
        }

        public Task<Multitable> GetRequirementSystemByIdAsync(string systemId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Multitable>> GetRequirementSystems(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Multitable> GetRequirementTopicByIdAsync(string requirementTopicId, string company, CancellationToken ct = default)
        {
            var requirementType = await _context.Multitables
                .Where<Multitable>((multitable) => multitable.TableName == $"REQ_TEMA_${company}" && multitable.CodeId == requirementTopicId)
                .FirstOrDefaultAsync(ct);

            return requirementType ?? throw new SgiAzureException($"No existe tipo de tema con id {requirementTopicId}", ErrorCode.EntityNotFound);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementTopics(string company, CancellationToken ct = default)
        {
            if (company == null) throw new ArgumentNullException(company);
            return await _context.Multitables.Where(multitable => multitable.TableName == $"REQ_TEMA_${company}" && multitable.IsActive =="S").ToListAsync(ct);
        }

        public async Task<Multitable> GetRequirementTypeByIdAsync(string requirementTypeId, CancellationToken ct = default)
        {
            var requirementType = await _context.Multitables
                .Where<Multitable>((multitable)=> multitable.TableName == "TIPRQ" && multitable.CodeId==requirementTypeId)
                .FirstOrDefaultAsync(ct);

            return requirementType ?? throw new SgiAzureException($"No existe tipo de requerimiento con id {requirementTypeId}", ErrorCode.EntityNotFound);
        }

        public async Task<IEnumerable<Multitable>> GetRequirementTypes(CancellationToken ct = default)
        {
            return await _context.Multitables
                .Where((multitable) => multitable.TableName == "TIPRQ" && multitable.IsActive == "S")
                .ToListAsync(ct);
        }
    }
}
