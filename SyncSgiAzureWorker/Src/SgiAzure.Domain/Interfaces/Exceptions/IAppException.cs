using SgiAzure.Domain.Enumerators;

namespace SgiAzure.Domain.Interfaces.Exceptions
{
    public interface IAppException
    {
        ErrorCode? CodeError { get; }

        object? Detail { get; }

    }
}
