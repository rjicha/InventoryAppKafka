using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InventoryApp.Persistence.Kafka.Producer
{
    public class ProducerContextFactory
    {
        private readonly ILogger<ProducerContextFactory> _logger;

        private readonly string _bootstrapServers;
        private readonly string _schemaRegistryUrl;

        public ProducerContextFactory(IConfiguration configuration, ILogger<ProducerContextFactory> logger)
        {
            _logger = logger;

            _bootstrapServers = configuration["KAFKA_BOOTSTRAP_SERVERS"];
            _schemaRegistryUrl = configuration["KAFKA_SCHEMA_REGISTRY_URL"];
        }


        public ProducerContext<T> GetContext<T>() where T : class, IMessage<T>, new()
        {
            _logger.LogDebug("Creating kafka producer");

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = _schemaRegistryUrl,
            };

            return new ProducerContext<T>(
                producerConfig,
                new CachedSchemaRegistryClient(schemaRegistryConfig)
            );
        }
    }
}