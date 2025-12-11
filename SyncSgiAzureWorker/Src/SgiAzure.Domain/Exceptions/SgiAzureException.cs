using SgiAzure.Domain.Enumerators;

namespace SgiAzure.Domain.Exceptions
{
    public class SgiAzureException : AppException
    {
        public SgiAzureException(string message, ErrorCode? codeError = null, object? detail = null, Exception? innerException = null) : base(message, codeError, detail, innerException)
        {
        }
    }
}
