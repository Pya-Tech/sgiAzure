namespace SgiAzure.Application.Interfaces.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
        Task<TDestination> Map(TSource source, int customerId);
    }
}
