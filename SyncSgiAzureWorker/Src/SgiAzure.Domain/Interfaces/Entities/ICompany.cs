using System;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Define los contratos para una entidad de empresa.
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la empresa.
        /// Este valor puede ser nulo para empresas nuevas o no registradas.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre o descripción de la empresa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el departamento asociado a la empresa.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Obtiene o establece el municipio donde se encuentra ubicada la empresa.
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario que creó o gestiona el registro de la empresa.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si esta empresa es la principal en el sistema.
        /// </summary>
        public string IsPrimary { get; set; }
    }
}
