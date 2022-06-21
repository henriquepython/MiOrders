using AutoMapper;
using OrderService.Domain.Models;
using OrderService.Service.API.Models;


namespace OrderService.Services.API.Configuration.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Order, CreateOrderViewModel>();          
            CreateMap<Product, CreateProductViewModel>();
            CreateMap<Cart, CreateCartViewModel>();
            CreateMap<User, CreateUserViewModel>();
        }
    }
}