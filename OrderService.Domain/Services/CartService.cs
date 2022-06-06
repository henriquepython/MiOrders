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
        public Cart AddCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Cart findCartByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public string RemoveAllCart(string userId)
        {
            throw new NotImplementedException();
        }

        public string RemoveCart(string id)
        {
            throw new NotImplementedException();
        }
    }
}
