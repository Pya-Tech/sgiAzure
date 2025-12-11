using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgiAzure.Domain.Enum
{
    /// <summary>
    /// Enumeración que define los tipos de cambio posibles en el historial de cambios.
    /// </summary>
    public enum ChangeType
    {
        /// <summary>
        /// El cambio fue una creación.
        /// </summary>
        Created,

        /// <summary>
        /// El cambio fue una actualización.
        /// </summary>
        Updated,

        /// <summary>
        /// El cambio fue una eliminación.
        /// </summary>
        Deleted
    }
}
