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

        public async Task Commit()
        {
            await orderServiceContext.SaveChangesAsync();
        }

        public void Create(Order order)
        {
            orderServiceContext.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            orderServiceContext.Orders.Remove(order);
        }

        public async Task<ICollection<Order>> GetAll()
        {
            return await orderServiceContext.Orders.AsNoTracking().Include(prop => prop.user).ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await orderServiceContext.Orders.AsNoTracking().Include(e => e.user).Where(x => x.id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cart>> GetCartByUser(Guid userId)
        {
            return await orderServiceContext.Carts.AsNoTracking().Where(x => x.userId.Equals(userId)).ToListAsync();
        }

        public void Update(Order order)
        {
            orderServiceContext.Entry(order).State = EntityState.Modified;
        }

        public async Task<ICollection<Order>> FindOrderByUser(Guid userId)
        {
            return await orderServiceContext.Orders.AsNoTracking().Where(orders => orders.userId.Equals(userId)).ToListAsync();
        }
    }
}
