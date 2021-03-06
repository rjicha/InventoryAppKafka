using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InventoryApp.Persistence.Kafka.Consumer
{
    public class ConsumerContextFactory
    {
        private readonly ILogger<ConsumerContextFactory> _logger;

        private readonly string _bootstrapServers;
        private readonly string _schemaRegistryUrl;

        public ConsumerContextFactory(IConfiguration configuration, ILogger<ConsumerContextFactory> logger)
        {
            _logger = logger;
            
            _bootstrapServers = configuration["KAFKA_BOOTSTRAP_SERVERS"];
            _schemaRegistryUrl = configuration["KAFKA_SCHEMA_REGISTRY_URL"];
        }
        
        public ConsumerContext<T> GetContext<T>(string groupId) where T : class, IMessage<T>, new()
        {
            _logger.LogDebug("Creating kafka consumer");
            
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = _bootstrapServers,
                GroupId = groupId
            };
            
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = _schemaRegistryUrl,
            };
            
            return new ConsumerContext<T>(consumerConfig, new CachedSchemaRegistryClient(schemaRegistryConfig));
        }
    }
}