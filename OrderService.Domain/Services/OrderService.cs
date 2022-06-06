using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void CancelOrder(string id)
        {
            throw new NotImplementedException();
        }

        public void CompletedCancelOrder(string id)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> findAll()
        {
            throw new NotImplementedException();
        }

        public List<Order> FindOrderByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public void RequestCancelOrder(string id)
        {
            throw new NotImplementedException();
        }
    }
}
