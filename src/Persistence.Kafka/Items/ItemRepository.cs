using System.Threading.Tasks;
using Confluent.Kafka;
using InventoryApp.Domain;
using InventoryApp.Persistence.Kafka.Producer;
using InventoryApp.UseCase.Items.Port.Out;

namespace InventoryApp.Persistence.Kafka.Items
{
    public class ItemRepository : IItemSavePort
    {
        private readonly ProducerContextFactory _producerContext;

        public ItemRepository(ProducerContextFactory producerContext)
        {
            _producerContext = producerContext;
        }

        public async Task SaveAsync(Item item)
        {
            using var context = _producerContext.GetContext<Item>();
            await context.Producer.ProduceAsync("item-saved", new Message<string, Item>
            {
                Value = item
            });
        }
    }
}