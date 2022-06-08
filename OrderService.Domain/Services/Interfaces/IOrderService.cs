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
        Order CreateOrder(Order order);

        List<Order> findAll();

        List<Order> FindOrderByUser(String userId);

        void CancelOrder(String id);

        void RequestCancelOrder(String id);

        void CompletedCancelOrder(String id);

    }
}
