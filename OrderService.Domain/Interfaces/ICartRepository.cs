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
        void Create(Cart cart);

        void Update(Cart cart);

        IList<Cart> GetAll();

        Cart GetById(String id);

        IList<Cart> GetByUser(String userId);

        void Commit();

        void DeleteOne(Cart cart);

        void DeleteMany();
    }
}
