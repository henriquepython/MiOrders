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

        ICollection<Cart> GetAll();

        Cart GetById(Guid id);

        List<Cart> GetByUser(Guid userId);

        void Commit();

        void DeleteOne(Product product);

        void DeleteMany();
    }
}
