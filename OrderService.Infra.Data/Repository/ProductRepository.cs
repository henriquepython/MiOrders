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
    public class ProductRepository : IProductRepository
    {
        private readonly OrderServiceContext orderServiceContext;

        public ProductRepository(OrderServiceContext orderServiceContext)
        {
            this.orderServiceContext = orderServiceContext;
        }

        public void Create(Product product)
        {
            orderServiceContext.Products.Add(product);
        }

        public void Delete(Product product)
        {
            orderServiceContext.Products.Remove(product);
        }

        public ICollection<Product> GetAll()
        {
            return orderServiceContext.Products.ToList();
        }

        public Product GetByid(Guid id)
        {
            return orderServiceContext.Products.FirstOrDefault(x => x.id.Equals(id));
        }

        public void Update(Product product)
        {
            
        }

        public void Commit()
        {
            orderServiceContext.SaveChanges();
        }
    }
}
