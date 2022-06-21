using OrderService.Domain.Interfaces;
using OrderService.Domain.Services;
using OrderService.Infra.Data.Repository;

namespace OrderService.Service.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderServices>();
        }
    }
}
