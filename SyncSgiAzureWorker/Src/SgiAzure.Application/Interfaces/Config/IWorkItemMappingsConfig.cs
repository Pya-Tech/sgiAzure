namespace SgiAzure.Application.Interfaces.Config
{
    /// <summary>
    /// Interfaz que define los mapeos de configuraciones de tipos de trabajo y prioridades
    /// para los elementos de trabajo (WorkItems) utilizados en Azure DevOps.
    /// </summary>
    public interface IWorkItemMappingsConfig
    {
        /// <summary>
        /// Obtiene un diccionario que mapea los tipos de trabajo (WorkItemEntity Types) a su descripción.
        /// El diccionario tiene como clave un código de tipo de trabajo (ej. "GT2", "ACT", etc.)
        /// y como valor la descripción del tipo de trabajo correspondiente (ej. "Bug", "Feature", etc.).
        /// </summary>
        /// <example>
        /// "GT2" -> "Bug"
        /// "ACT" -> "Feature"
        /// </example>
        Dictionary<string, string> Types { get; }

        /// <summary>
        /// Obtiene un diccionario que mapea los niveles de prioridad de los elementos de trabajo (WorkItemEntity Priorities).
        /// El diccionario tiene como clave el valor numérico de la prioridad (ej. 1, 2, 3, etc.) 
        /// y como valor la descripción de la prioridad correspondiente (ej. "1", "2", "3").
        /// </summary>
        /// <example>
        /// 1 -> "1"
        /// 2 -> "2"
        /// </example>
        Dictionary<int, string> Priorities { get; }


        /// <summary>
        /// Obtiene un diccionario que mapea los niveles de prioridad de los elementos de trabajo (WorkItemEntity Priorities).
        /// El diccionario tiene como clave el valor numérico de la prioridad (ej. 1, 2, 3, etc.) 
        /// y como valor la descripción de la prioridad correspondiente (ej. "1", "2", "3").
        /// </summary>
        /// <example>
        /// 1 -> "1"
        /// 2 -> "2"
        /// </example>
        Dictionary<string, string> Statuses { get; }
    }
}
