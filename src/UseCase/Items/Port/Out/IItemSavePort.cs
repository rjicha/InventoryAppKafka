using System.Threading.Tasks;

namespace InventoryApp.UseCase.Items.Port.Out
{
    public interface IItemSavePort
    {
        Task SaveAsync(Domain.Item person);
    }
}