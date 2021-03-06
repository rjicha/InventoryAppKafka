using System.Threading.Tasks;

namespace InventoryApp.UseCase.Items
{
    public interface ICreateItemUseCase
    {
        Task RegisterAsync(Domain.Item item);
    }
}