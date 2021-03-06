using Microsoft.Extensions.DependencyInjection;

namespace InventoryApp.Api.Configuration
{
    internal static class Cors
    {
        internal static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}