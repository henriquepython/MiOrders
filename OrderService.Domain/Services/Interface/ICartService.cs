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
       Cart AddCart(Cart cart);

       Cart findCartByUser(String userId);



       String RemoveCart(String id);

       String RemoveAllCart(String userId);
    }
}
