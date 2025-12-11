using Polly;
using Polly.Retry;

namespace SgiAzure.Worker.Extensions
{
    public static class ResilienceExtensions
    {
        public static IServiceCollection AddResilience(this IServiceCollection services)
        {
            services.AddResiliencePipeline<string>("message-pipeline", pipeline =>
            {
                pipeline.AddRetry(new RetryStrategyOptions
                {
                    MaxRetryAttempts = 3,
                    BackoffType = DelayBackoffType.Exponential,
                    Delay = TimeSpan.FromSeconds(2)
                });

                pipeline.AddTimeout(TimeSpan.FromSeconds(30));
            });

            return services;
        }
    }
}
