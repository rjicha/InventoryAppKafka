using System;
using System.Threading;
using InventoryApp.Domain;
using InventoryApp.Persistence.Kafka.Consumer;

namespace InventoryApp.Consumer
{
    public class ItemTopicsConsumer
    {
        private readonly ConsumerContextFactory _consumerContextFactory;

        public ItemTopicsConsumer(ConsumerContextFactory consumerContextFactory)
        {
            _consumerContextFactory = consumerContextFactory;
        }

        public void Listen(string topic, CancellationTokenSource cts)
        {
            using var context = _consumerContextFactory.GetContext<Item>("test-group");
            context.Consumer.Subscribe(topic);

            try
            {
                while (true)
                {
                    var consumeResult = context.Consumer.Consume(cts.Token);
                    
                    Console.WriteLine(
                        $"Kafka topic [{topic}] result: {consumeResult.Message.Value.Title}" +
                        $" @ {consumeResult.Message.Value.Room}"
                    );
                }
            }
            catch
            {
                context.Consumer.Close();
            }
        }
    }
}