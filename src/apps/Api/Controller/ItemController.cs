using System.Threading.Tasks;
using InventoryApp.UseCase.Items;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Api.Controller
{
    public class ItemController : ApiController
    {
        private readonly ICreateItemUseCase _createItemUseCase;

        public ItemController(ICreateItemUseCase createItemUseCase)
        {
            _createItemUseCase = createItemUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Domain.Item item)
        {
            await _createItemUseCase.RegisterAsync(item);
            return Ok();
        }
    }
}