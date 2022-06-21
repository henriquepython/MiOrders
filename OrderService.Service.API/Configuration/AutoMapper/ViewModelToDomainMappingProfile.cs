using AutoMapper;
using OrderService.Domain.Models;
using OrderService.Service.API.Models;

namespace OrderService.Services.API.Configuration.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateOrderViewModel, Order>();
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<CreateCartViewModel, Cart>();
            CreateMap<CreateUserViewModel, User>();
        }
    }
}