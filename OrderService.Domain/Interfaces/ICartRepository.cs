using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface ICartRepository
    {
        Cart Create(Cart cart);

        Cart Update(Cart cart);

        List<Cart> GetAll();

        Cart GetById(String id);

        List<Cart> GetByUser(String userId);

        List<Cart> GetByProduct(String productId);

        void DeleteOne(String id);

        void DeleteMany();
    }
}
