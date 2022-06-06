using OrderService.Domain.Interfaces;
using OrderService.Domain.Services;

namespace OrderService.Service.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
        }
    }
}
