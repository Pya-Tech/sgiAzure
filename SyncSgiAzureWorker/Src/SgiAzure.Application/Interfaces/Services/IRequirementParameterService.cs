using SgiAzure.Application.Interfaces.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SgiAzure.Application.Interfaces.Services
{
    public interface IRequirementParameterService<TRequirementTypeDto, TCompanyDto, TSystemDto, TAreaDto, TSubAreaDto, TClasificationDto, TTopicDto>
        where TRequirementTypeDto : IRequirementTypeDto
        where TCompanyDto : IRequirementCompanyDto
        where TSystemDto : IRequirementSystemDto
        where TAreaDto : IRequirementAreaDto
        where TSubAreaDto : IRequirementSubAreaDto
        where TClasificationDto : IRequirementClasificationDto
        where TTopicDto : IRequirementTopicDto
    {
        /// <summary>
        /// Obtiene todos los tipos de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de tipos de requerimiento.</returns>
        Task<IEnumerable<TRequirementTypeDto>> GetRequirementTypes();

        /// <summary>
        /// Obtiene todas las empresas disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de empresas.</returns>
        Task<IEnumerable<TCompanyDto>> GetCompanies();

        /// <summary>
        /// Obtiene todos los sistemas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de sistemas de requerimiento.</returns>
        Task<IEnumerable<TSystemDto>> GetRequirementSystems();

        /// <summary>
        /// Obtiene todas las áreas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de áreas de requerimiento.</returns>
        Task<IEnumerable<TAreaDto>> GetRequirementAreas();

        /// <summary>
        /// Obtiene todas las sub-áreas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de sub-áreas de requerimiento.</returns>
        Task<IEnumerable<TSubAreaDto>> GetRequirementSubAreas();

        /// <summary>
        /// Obtiene todas las clasificaciones de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de clasificaciones de requerimiento.</returns>
        Task<IEnumerable<TClasificationDto>> GetRequirementClasifications();

        /// <summary>
        /// Obtiene todos los temas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de temas de requerimiento.</returns>
        Task<IEnumerable<TTopicDto>> GetRequirementTopics();

        /// <summary>
        /// Obtiene un tipo de requerimiento específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del tipo de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el tipo de requerimiento encontrado.</returns>
        Task<TRequirementTypeDto> GetRequirementTypeByIdAsync(int id);

        /// <summary>
        /// Obtiene una empresa específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único de la empresa a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con la empresa encontrada.</returns>
        Task<TCompanyDto> GetCompanyByIdAsync(int id);

        /// <summary>
        /// Obtiene un sistema de requerimiento específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del sistema de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el sistema de requerimiento encontrado.</returns>
        Task<TSystemDto> GetRequirementSystemByIdAsync(int id);

        /// <summary>
        /// Obtiene un área de requerimiento específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del área de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el área de requerimiento encontrada.</returns>
        Task<TAreaDto> GetRequirementAreaByIdAsync(int id);

        /// <summary>
        /// Obtiene una sub-área de requerimiento específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único de la sub-área de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con la sub-área de requerimiento encontrada.</returns>
        Task<TSubAreaDto> GetRequirementSubAreaByIdAsync(int id);

        /// <summary>
        /// Obtiene una clasificación de requerimiento específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único de la clasificación de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con la clasificación de requerimiento encontrada.</returns>
        Task<TClasificationDto> GetRequirementClasificationByIdAsync(int id);

        /// <summary>
        /// Obtiene un tema de requerimiento específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del tema de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el tema de requerimiento encontrado.</returns>
        Task<TTopicDto> GetRequirementTopicByIdAsync(int id);
    }
}
