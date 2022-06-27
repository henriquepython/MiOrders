using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface ICartService
    { 
       Task<Cart> addItemCart(Cart cart);

       Task<IEnumerable<Cart>> findCartByUser(Guid userId);

       Task removeItemCart(Cart cart);

       Task removeAllCart(Guid userId);
    }
}
