namespace ServiceHook.Application.Interfaces.Config
{
    public interface IBrokerMessageConfiguration<T> where T : IQueueConfiguration
    {
        string Exchange { get; }
        IDictionary<string,T> Queues { get; }
    }
}
