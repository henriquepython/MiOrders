using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task Create(Order order);

        Task Update(Order order);

        Task<ICollection<Order>> FindOrderByUser(Guid userId);

        Task<Order> GetById(Guid id);

        Task<IList<Cart>> GetCartByUser(Guid userId);

        Task<ICollection<Order>> GetAll();

        Task Delete(Order order);

        Task Commit();
    }
}
