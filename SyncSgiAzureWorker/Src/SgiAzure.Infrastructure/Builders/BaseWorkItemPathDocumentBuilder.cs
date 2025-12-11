using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Infrastructure.Builders
{
    /// <summary>
    /// Clase base abstracta para construir documentos de parche (<see cref="JsonPatchDocument"/>) utilizados en la modificación de WorkItems en Azure DevOps.
    /// Proporciona métodos comunes para agregar campos y generar documentos de parche, facilitando la construcción incremental.
    /// </summary>
    /// <remarks>
    /// Inicializa una nueva instancia de la clase <see cref="BaseWorkItemPatchDocumentBuilder"/> con la configuración especificada.
    /// </remarks>
    /// <param name="fieldsConfiguration">Configuración de los campos de Azure DevOps utilizada para construir el documento.</param>
    public abstract class BaseWorkItemPatchDocumentBuilder(AzureFieldsConfiguration fieldsConfiguration)
    {
        /// <summary>
        /// Configuración de campos de Azure DevOps, utilizada para mapear claves específicas de los campos.
        /// </summary>
        protected readonly AzureFieldsConfiguration _fieldsConfiguration = fieldsConfiguration;

        /// <summary>
        /// Documento de parche (<see cref="JsonPatchDocument"/>) que acumula las operaciones a aplicar al WorkItemEntity.
        /// Se inicializa y reinicia cada vez que se genera un nuevo documento.
        /// </summary>
        private readonly JsonPatchDocument _patchDocument = [];


        /// <summary>
        /// Agrega una operación de parche al documento para modificar un campo de un WorkItemEntity en Azure DevOps.
        /// </summary>
        /// <param name="path">La ruta del campo en el WorkItemEntity (por ejemplo, "/fields/System.Title").</param>
        /// <param name="value">El valor que se asignará al campo especificado.</param>
        /// <param name="operation">El tipo de operación de parche a realizar. Por defecto es <see cref="Operation.Add"/>.</param>
        /// <exception cref="ArgumentException">Se lanza si la ruta del campo está vacía o nula.</exception>
        /// <exception cref="ArgumentNullException">Se lanza si el valor del campo es nulo.</exception>
        protected void AddField(string path, object? value, Operation operation = Operation.Add)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("La ruta del campo no puede estar vacía.", nameof(path));

            if (value == null || value.ToString() == string.Empty) return;
            _patchDocument.Add(new JsonPatchOperation
            {
                Operation = operation,
                Path = path,
                Value = value
            });
        }

        /// <summary>
        /// Construye el documento de parche con todas las operaciones acumuladas y reinicia el documento para su reutilización.
        /// </summary>
        /// <returns>Un <see cref="JsonPatchDocument"/> que contiene todas las operaciones de parche acumuladas.</returns>
        /// <remarks>
        /// Este método debe llamarse después de agregar todas las operaciones necesarias utilizando <see cref="AddField"/>.
        /// Una vez llamado, el documento de parche actual se reinicia para su próxima construcción.
        /// </remarks>
        public JsonPatchDocument Build()
        {
            var result = _patchDocument;
            return result;
        }
    }
}
