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

        public void Commit()
        {
            orderServiceContext.SaveChanges();
        }

        public void Create(Cart cart)
        {
            orderServiceContext.Carts.Add(cart);
        }

        public void DeleteMany()
        {
            orderServiceContext.Carts.RemoveRange(orderServiceContext.Carts);
        }

        public void DeleteOne(Cart cart)
        {
            orderServiceContext.Carts.Remove(cart);
        }

        public IList<Cart> GetAll()
        {
            return orderServiceContext.Carts.AsNoTracking().ToList();
        }

        public Cart GetById(String id)
        {
            return orderServiceContext.Carts.AsNoTracking().Where(x => x.id.Equals(id)).FirstOrDefault();
        }

        public IList<Cart> GetByUser(String userId)
        {
            return orderServiceContext.Carts.AsNoTracking().Where(x => x.userId.Equals(userId)).ToList();
        }

        public void Update(Cart cart)
        {
            orderServiceContext.Carts.Update(cart);
        }
    }
}
