using System;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Google.Protobuf;

namespace InventoryApp.Persistence.Kafka.Consumer
{
    public class ConsumerContext<T> : IDisposable where T : class, IMessage<T>, new()
    {
        public readonly IConsumer<string, T> Consumer;
        
        private readonly ISchemaRegistryClient _registry;

        internal ConsumerContext(ConsumerConfig config, ISchemaRegistryClient registry)
        {
            _registry = registry;

            Consumer = new ConsumerBuilder<string, T>(config)
                .SetValueDeserializer(new ProtobufDeserializer<T>().AsSyncOverAsync())
                .Build();
        }
        
        public void Dispose()
        {
            _registry?.Dispose();
            Consumer?.Dispose();
        }
    }
}