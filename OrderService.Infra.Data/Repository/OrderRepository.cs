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

        public async Task Create(Order order)
        {
            orderServiceContext.Orders.Add(order);
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            orderServiceContext.Orders.Remove(order);
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAll()
        {
            return await orderServiceContext.Orders.Include(prop => prop.user).AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await orderServiceContext.Orders.AsNoTracking().Include(e => e.user).Where(x => x.id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IList<Cart>> GetCartByUser(Guid userId)
        {
            return await orderServiceContext.Carts.Where(x => x.userId.Equals(userId)).ToListAsync();
        }

        public async Task Update(Order order)
        {
            orderServiceContext.Orders.Update(order);
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> FindOrderByUser(Guid userId)
        {
            return await orderServiceContext.Orders.AsNoTracking().Where(orders => orders.userId.Equals(userId)).ToListAsync();
        }
    }
}
