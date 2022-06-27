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
        public async Task<ActionResult<IEnumerable<CreateOrderViewModel>>> Get()
        {
            return Ok(await orderService.findAll());
        }

        [HttpGet("userId")]
        public async Task<ActionResult<ICollection<CreateOrderViewModel>>> FindOrderByUser(Guid userId)
        {
            var orderId = await orderService.FindOrderByUser(userId);

            if (orderId is null)
            {
                return NotFound("order not found");
            }

            var orderMapper = mapper.Map<Order>(orderId);
            return Ok(orderMapper);
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderViewModel>> Create(CreateOrderViewModel order)
        {
            if (order is null)
            {
                return BadRequest();
            }

            var orderCreated = await orderService.CreateOrder(mapper.Map<Order>(order));
            return Ok(orderCreated);
        }

        [HttpPost("/CompletedOrder")]
        public async Task<IActionResult> CompletedOrder(Guid id)
        { 
            await orderService.CompletedOrder(id);
            return NoContent();
        }

        [HttpPost("/CancelOrder")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            await orderService.CancelOrder(id);
            return NoContent();
        }

        [HttpPost("/RequestCancelOrder")]
        public async Task<IActionResult> RequestCancelOrder(Guid id)
        {
            await orderService.RequestCancelOrder(id);
            return NoContent();
        }
    }
}
