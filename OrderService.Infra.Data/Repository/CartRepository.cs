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

        public void DeleteOne(Product product)
        {
            orderServiceContext.Remove(product);
        }

        public ICollection<Cart> GetAll()
        {
            return orderServiceContext.Carts.ToList();
        }

        public Cart GetById(Guid id)
        {
            return orderServiceContext.Carts.FirstOrDefault(x => x.id.Equals(id));
        }

        public List<Cart> GetByUser(Guid userId)
        {
            return orderServiceContext.Carts.Where(b => b.userId.Equals(userId)).ToList();
        }

        public Cart Update(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
