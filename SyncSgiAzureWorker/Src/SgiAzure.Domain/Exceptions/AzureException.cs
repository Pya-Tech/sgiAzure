using SgiAzure.Domain.Enumerators;

namespace SgiAzure.Domain.Exceptions
{
    public class AzureException : AppException
    {
        public AzureException(string message, ErrorCode? codeError = null, object? detail = null, Exception? innerException = null) : base(message, codeError, detail, innerException)
        {
        }
    }
}
