using InventoryApp.Persistence.Kafka.Producer;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApp.Api.Configuration
{
    internal static class Kafka
    {
        internal static void ConfigureKafka(this IServiceCollection services)
        {
            services.AddSingleton<ProducerContextFactory>();
        }
    }
}