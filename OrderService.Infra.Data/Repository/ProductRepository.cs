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

        public async Task Commit()
        {
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task<Product> Create(Product product)
        {
            orderServiceContext.Products.Add(product);
            await orderServiceContext.SaveChangesAsync();
            return product;
        }

        public async Task Delete(Product product)
        {
            orderServiceContext.Products.Remove(product);
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await orderServiceContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await orderServiceContext.Products.AsNoTracking().Where(product => product.id.Equals(productId)).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Product>> GetProductByCategory(string productCategory)
        {
            return await orderServiceContext.Products.AsNoTracking().Where(product => product.category.Equals(productCategory)).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductByTitle(string title)
        {
            return await orderServiceContext.Products.AsNoTracking().Where(product => product.title.Equals(title)).ToListAsync();
        }

        public async Task Update(Product product)
        {
            orderServiceContext.Products.Update(product);
            await orderServiceContext.SaveChangesAsync();
        }
    }
}
