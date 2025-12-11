using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Interfaces.Exceptions;

namespace SgiAzure.Domain.Exceptions
{
    /// <summary>
    /// Excepción base para todos los errores de negocio de la aplicación.
    /// Contiene un código interno y datos de contexto para diagnóstico.
    /// </summary>
    public class AppException : Exception, IAppException
    {
        /// <summary>
        /// Código interno único del error (puede usarse para mapeo a mensajes o traducciones).
        /// </summary>
        public ErrorCode? CodeError { get; }

        /// <summary>
        /// Información adicional del error, como datos de contexto o validación.
        /// </summary>
        public object? Detail { get; }

        /// <summary>
        /// Crea una nueva instancia de la excepción de aplicación.
        /// </summary>
        /// <param name="message">Mensaje descriptivo del error.</param>
        /// <param name="codeError">Código único del error.</param>
        /// <param name="detail">Objeto con información de contexto.</param>
        /// <param name="innerException">Excepción que originó este error, si aplica.</param>
        protected AppException(
            string message,
            ErrorCode? codeError = null,
            object? detail = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            CodeError = codeError;
            Detail = detail;
        }
    }
}
