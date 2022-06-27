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
    public class CartRepository : ICartRepository
    {
        private readonly OrderServiceContext orderServiceContext;

        public CartRepository(OrderServiceContext orderServiceContext)
        {
            this.orderServiceContext = orderServiceContext;
        }

        public async Task commit()
        {
            await orderServiceContext.SaveChangesAsync();
        }

        public void create(Cart cart)
        {
            orderServiceContext.Carts.Add(cart);
        }

        public void deleteMany(Guid userId)
        {
            var cartById = orderServiceContext.Carts.Where(cart => cart.userId.Equals(userId)).ToList();
            orderServiceContext.Carts.RemoveRange(cartById);
        }

        public void deleteOne(Cart cart)
        {
            orderServiceContext.Carts.Remove(cart); 
        }

        public async Task<IEnumerable<Cart>> getAll()
        {
            return await orderServiceContext.Carts.AsNoTracking().ToListAsync();
        }

        public async Task<Cart> getById(Guid id)
        {
            return await orderServiceContext.Carts.AsNoTracking().Where(cart => cart.id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cart>> getByUser(Guid userId)
        {
            return await orderServiceContext.Carts.AsNoTracking().Where(cart => cart.userId.Equals(userId)).ToListAsync();
        }

        public void update(Cart cart)
        {
            orderServiceContext.Carts.Update(cart);
        }
    }
}
