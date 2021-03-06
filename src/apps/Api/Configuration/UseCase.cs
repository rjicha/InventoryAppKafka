using InventoryApp.UseCase.Items;
using InventoryApp.UseCase.Items.Service;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApp.Api.Configuration
{
    internal static class UseCase
    {
        internal static void RegisterUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateItemUseCase, PersonService>();
        }
    }
}