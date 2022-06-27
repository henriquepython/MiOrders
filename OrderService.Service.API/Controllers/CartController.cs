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
        public async Task<ActionResult<IEnumerable<Cart>>> GetByUser(Guid userId)
        {
            var cartId = await cartService.findCartByUser(userId);

            if (cartId == null)
            {
                return NotFound("cart not found");
            }

            return Ok(cartId);
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<CreateCartViewModel>> AddItemCart([FromBody] CreateCartViewModel cart)
        {
            return Ok(await cartService.addItemCart(mapper.Map<Cart>(cart)));
        }


        // DELETE ONE
        [HttpDelete]
        public async Task<IActionResult> deleteOne(Cart cart)
        {
            await cartService.removeItemCart(cart);
            return NoContent();
        }

        // DELETE ALL BY USER
        [HttpDelete("/user/{userId}")]
        public async Task<IActionResult> deleteByUser(Guid userId)
        {
            await cartService.removeAllCart(userId);
            return NoContent();
        }
    }
}
