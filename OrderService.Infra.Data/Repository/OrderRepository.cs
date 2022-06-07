using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IList<Order> GetAll()
        {
            return orderServiceContext.Orders.AsNoTracking().ToList();
        }

        public Order GetById(String id)
        {
            return orderServiceContext.Orders.AsNoTracking().Where(x => x.id.Equals(id)).FirstOrDefault();
        }

        public void Update(Order order)
        {
            orderServiceContext.Orders.Update(order);
        }
    }
}
