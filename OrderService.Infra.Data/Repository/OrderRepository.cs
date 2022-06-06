using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Infra.Data.Context;

namespace OrderService.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderServiceContext orderServiceContext;

        public OrderRepository(OrderServiceContext orderServiceContext)
        {
            this.orderServiceContext = orderServiceContext;
        }

        public void Commit()
        {
            orderServiceContext.SaveChanges();
        }

        public void Create(Order order)
        {
            orderServiceContext.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            orderServiceContext.Orders.Remove(order);
        }

        public ICollection<Order> GetAll()
        {
            return orderServiceContext.Orders.ToList();
        }

        public Order GetById(Guid id)
        {
            return orderServiceContext.Orders.FirstOrDefault(x => x.id.Equals(id));
        }

        public void Update(Order order)
        {
            
        }
    }
}
