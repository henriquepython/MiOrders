using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Service.API.Models;

namespace OrderService.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }


        // GET BY USER
        [HttpGet("{userId}")]
        public async Task<ActionResult<ICollection<Cart>>> GetByUser(Guid userId)
        {
            return Ok(await cartService.findCartByUser(userId));
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<CreateCartViewModel>> AddItemCart([FromBody] CreateCartViewModel cart)
        {
            return Ok(await cartService.addItemCart(mapper.Map<Cart>(cart)));
        }


        // DELETE ONE
        [HttpDelete]
        public async Task deleteOne(Cart cart)
        {
            await cartService.removeItemCart(cart);
        }

        // DELETE ALL BY USER
        [HttpDelete("/user/{userId}")]
        public async Task deleteByUser(Guid userId)
        {
            await cartService.removeAllCart(userId);
        }
    }
}
