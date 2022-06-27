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
        void create(Cart cart);

        void update(Cart cart);

        Task<IEnumerable<Cart>> getAll();

        Task<Cart> getById(Guid id);

        Task<IEnumerable<Cart>> getByUser(Guid userId);

        Task commit();

        void deleteOne(Cart cart);

        void deleteMany(Guid userId);
    }
}
