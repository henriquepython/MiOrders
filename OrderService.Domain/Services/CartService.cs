using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<Cart> addItemCart(Cart cart)
        {
            return await cartRepository.create(cart);
        }

        public async Task<ICollection<Cart>> findCartByUser(Guid userId)
        {
            return await cartRepository.getByUser(userId);
        }

        public async Task removeAllCart(Guid userId)
        {
            await cartRepository.deleteMany(userId);
        }

        public async Task removeItemCart(Cart cart)
        {
            await cartRepository.deleteOne(cart);
        }
    }
}
