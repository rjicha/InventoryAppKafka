using System.Threading.Tasks;
using InventoryApp.UseCase.Items.Port.Out;

namespace InventoryApp.UseCase.Items.Service
{
    public class PersonService : ICreateItemUseCase
    {
        private readonly IItemSavePort _savePort;

        public PersonService(IItemSavePort savePort)
        {
            _savePort = savePort;
        }

        public Task RegisterAsync(Domain.Item item)
        {
            return _savePort.SaveAsync(item);
        }
    }
}