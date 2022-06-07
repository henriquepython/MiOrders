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
    public class ProductRepository : IProductRepository
    {
        private readonly OrderServiceContext orderServiceContext;

        public ProductRepository(OrderServiceContext orderServiceContext)
        {
            this.orderServiceContext = orderServiceContext;
        }

        public void Commit()
        {
            orderServiceContext.SaveChanges();
        }

        public void Create(Product product)
        {
            orderServiceContext.Products.Add(product);
        }

        public void Delete(Product product)
        {
            orderServiceContext.Products.Remove(product);
        }

        public IList<Product> GetAll()
        {
            return orderServiceContext.Products.AsNoTracking().ToList();
        }

        public Product GetByid(String id)
        {
            return orderServiceContext.Products.AsNoTracking().Where(x => x.id.Equals(id)).FirstOrDefault();
        }

        public void Update(Product product)
        {
            orderServiceContext.Products.Update(product);
        }
    }
}
