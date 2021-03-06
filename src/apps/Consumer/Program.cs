using System.Threading;
using System.Threading.Tasks;
using InventoryApp.Persistence.Kafka.Consumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var services = ConfigureServices(serviceCollection);
            
            var itemsConsumer = services.GetService<ItemTopicsConsumer>();
            var cts = new CancellationTokenSource();
            
            
            itemsConsumer?.Listen("item-saved", cts);
        }

        private static ServiceProvider ConfigureServices(ServiceCollection services)
        {
            services.AddLogging().AddTransient<ConsumerContextFactory>();
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)   
                .Build();

            services.AddSingleton<IConfiguration>(config);
            services.AddTransient<ConsumerContextFactory>();
            services.AddTransient<ItemTopicsConsumer>();
            return services.BuildServiceProvider();

        }
    }
}