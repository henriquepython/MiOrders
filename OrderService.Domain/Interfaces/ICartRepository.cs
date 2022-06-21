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
        Task<Cart> create(Cart cart);

        Task update(Cart cart);

        Task<ICollection<Cart>> getAll();

        Task<Cart> getById(Guid id);

        Task<ICollection<Cart>> getByUser(Guid userId);

        Task commit();

        Task deleteOne(Cart cart);

        Task deleteMany(Guid userId);
    }
}
