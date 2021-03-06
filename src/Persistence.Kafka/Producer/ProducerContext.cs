using System;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Google.Protobuf;

namespace InventoryApp.Persistence.Kafka.Producer
{
    public class ProducerContext<T> : IDisposable where T : class, IMessage<T>, new()
    {
        public readonly IProducer<string, T> Producer;
        
        private readonly ISchemaRegistryClient _registry;

        internal ProducerContext(ProducerConfig config, ISchemaRegistryClient registry)
        {
            _registry = registry;

            Producer = new ProducerBuilder<string, T>(config)
                .SetValueSerializer(new ProtobufSerializer<T>(_registry))
                .Build();
        }

        public void Dispose()
        {
            _registry?.Dispose();
            Producer?.Dispose();
        }
    }
}