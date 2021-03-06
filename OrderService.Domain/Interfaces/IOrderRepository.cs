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
        void Create(Order order);

        void Update(Order order);

        Task<IEnumerable<Order>> FindOrderByUser(Guid userId);

        Task<Order> GetById(Guid id);

        Task<IEnumerable<Cart>> GetCartByUser(Guid userId);

        Task<IEnumerable<Order>> GetAll();

        void Delete(Order order);

        Task Commit();
    }
}
