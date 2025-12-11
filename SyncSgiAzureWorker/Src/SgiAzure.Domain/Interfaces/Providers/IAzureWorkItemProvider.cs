namespace SgiAzure.Domain.Interfaces.Providers
{
    /// <summary>
    /// Interfaz que define los métodos para interactuar con los Work Items de Azure DevOps. 
    /// Esta interfaz permite crear, actualizar, eliminar, clonar, cambiar el tipo, añadir comentarios y obtener Work Items 
    /// desde Azure DevOps de manera asíncrona.
    /// </summary>
    /// <typeparam name="T">Tipo genérico que representa el objeto asociado al Work Item, como un modelo de datos o entidad.</typeparam>
    public interface IAzureWorkItemProvider<T>
    {
        /// <summary>
        /// Crea un nuevo Work Item en Azure DevOps utilizando un objeto del tipo genérico <typeparamref name="T"/>.
        /// Este método realiza una operación asíncrona para crear el Work Item.
        /// </summary>
        /// <param name="workItem">Objeto del tipo <typeparamref name="T"/> que contiene los datos necesarios para crear un Work Item.</param>
        /// <returns>
        /// Un <see cref="Task{T}"/> que representa la operación asíncrona de creación, 
        /// con el Work Item creado representado como un objeto del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<T> CreateWorkItemAsync(T workItem);

        /// <summary>
        /// Actualiza un Work Item existente en Azure DevOps utilizando un objeto del tipo genérico <typeparamref name="T"/>.
        /// Este método realiza una operación asíncrona para actualizar los datos del Work Item.
        /// </summary>
        /// <param name="workItemId">El identificador único del Work Item que se va a actualizar.</param>
        /// <param name="workItem">Objeto del tipo <typeparamref name="T"/> que contiene los nuevos datos para actualizar el Work Item.</param>
        /// <returns>
        /// Un <see cref="Task{T}"/> que representa la operación asíncrona de actualización, 
        /// con el Work Item actualizado representado como un objeto del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<T> UpdateWorkItemAsync(int workItemId, T workItem);

        /// <summary>
        /// Elimina un Work Item existente en Azure DevOps utilizando su identificador.
        /// Este método realiza una operación asíncrona para eliminar el Work Item.
        /// </summary>
        /// <param name="workItemId">El identificador único del Work Item que se va a eliminar.</param>
        /// <returns>
        /// Un <see cref="Task"/> que representa la operación asíncrona de eliminación.
        /// </returns>
        Task DeleteWorkItemAsync(int workItemId);

        /// <summary>
        /// Cambia el tipo de un Work Item existente en Azure DevOps.
        /// Este método permite modificar el tipo de trabajo (por ejemplo, de Bug a Feature).
        /// </summary>
        /// <param name="workItemId">El identificador único del Work Item cuyo tipo se cambiará.</param>
        /// <param name="newType">El nuevo tipo para el Work Item (por ejemplo, "Bug", "Task", "Feature", etc.).</param>
        /// <returns>
        /// Un <see cref="Task{T}"/> que representa la operación asíncrona de cambio de tipo, 
        /// con el Work Item actualizado representado como un objeto del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<T> ChangeWorkItemTypeAsync(int workItemId, string newType);

        /// <summary>
        /// Clona un Work Item existente en Azure DevOps.
        /// Este método crea un nuevo Work Item con los mismos datos que el Work Item original.
        /// </summary>
        /// <param name="workItemId">El identificador único del Work Item que se va a clonar.</param>
        /// <returns>
        /// Un <see cref="Task{T}"/> que representa la operación asíncrona de clonación, 
        /// con el nuevo Work Item clonado representado como un objeto del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<T> CloneWorkItemAsync(int workItemId);

        /// <summary>
        /// Añade un comentario a un Work Item existente en Azure DevOps.
        /// Este método realiza una operación asíncrona para agregar el comentario.
        /// </summary>
        /// <param name="workItemId">El identificador único del Work Item al que se le añadirá el comentario.</param>
        /// <param name="comment">El comentario que se agregará al Work Item.</param>
        /// <returns>
        /// Un <see cref="Task{T}"/> que representa la operación asíncrona de añadir el comentario, 
        /// con el Work Item resultante representado como un objeto del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<T> AddCommentAsync(int workItemId, string comment);

        /// <summary>
        /// Obtiene un Work Item de Azure DevOps utilizando su identificador y lo convierte en un objeto del tipo <typeparamref name="T"/>.
        /// Este método realiza una operación asíncrona para obtener el Work Item y mapearlo a un objeto correspondiente.
        /// </summary>
        /// <param name="workItemId">El identificador único del Work Item que se desea obtener.</param>
        /// <returns>
        /// Un <see cref="Task{T}"/> que representa la operación asíncrona de obtención, 
        /// con el Work Item representado como un objeto del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<T> GetWorkItemAsync(int workItemId);

        /// <summary>
        /// Obtiene todos los Work Items de un proyecto específico de Azure DevOps.
        /// Este método realiza una operación asíncrona para obtener los Work Items y mapearlos a una lista de objetos del tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectName">El nombre del proyecto de Azure DevOps del cual se desean obtener los Work Items.</param>
        /// <returns>
        /// Un <see cref="Task{List{T}}"/> que representa la operación asíncrona de obtención, 
        /// con los Work Items representados como una lista de objetos del tipo <typeparamref name="T"/>.
        /// </returns>
        Task<List<T>> GetWorkItemsByProjectAsync(string projectName);

        /// <summary>
        /// Revierte los datos de un WorkItem a una revisión específica
        /// </summary>
        /// <param name="workItemId">Identificador del WorkItem</param>
        /// <param name="revisionId">Número de revisión del WorkItem</param>
        /// <returns>WorkItem revertido</returns>
        Task<T> RevertWorkItemToRevision(int workItemId, int revisionId);
    }
}
