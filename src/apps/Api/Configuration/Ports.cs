using InventoryApp.Persistence.Kafka.Items;
using InventoryApp.UseCase.Items.Port.Out;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApp.Api.Configuration
{
    internal static class Ports
    {
        internal static void RegisterPorts(this IServiceCollection services)
        {
            services.AddTransient<IItemSavePort, ItemRepository>();
        }
    }
}