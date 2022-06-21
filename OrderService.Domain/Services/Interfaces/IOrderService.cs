using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IOrderService
    { 
        Task <Order> CreateOrder(Order order);

        Task<ICollection<Order>> findAll();

        Task<ICollection<Order>> FindOrderByUser(Guid userId);

        Task CancelOrder(Guid id);

        Task RequestCancelOrder(Guid id);

        Task CompletedOrder(Guid id);

    }
}
