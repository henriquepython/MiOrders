using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Service.API.Models;

namespace OrderService.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    { 
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Order>>> Get()
        {
            return Ok(await orderService.findAll());
        }

        [HttpGet("userId")]
        public async Task<ActionResult<ICollection<Order>>> FindOrderByUser(Guid userId)
        {
            return Ok(await orderService.FindOrderByUser(userId));
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderViewModel>> Create(CreateOrderViewModel order)
        {
            return Ok(await orderService.CreateOrder(mapper.Map<Order>(order)));
        }

        [HttpPost("/CompletedOrder")]
        public async Task CompletedOrder(Guid id)
        { 
            await orderService.CompletedOrder(id);
        }

        [HttpPost("/CancelOrder")]
        public async Task CancelOrder(Guid id)
        {
            await orderService.CancelOrder(id);
        }

        [HttpPost("/RequestCancelOrder")]
        public async Task RequestCancelOrder(Guid id)
        {
            await orderService.RequestCancelOrder(id);
        }
    }
}
