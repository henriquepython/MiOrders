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

        public void Create(Product product)
        {
            orderServiceContext.Products.Add(product);
        }

        public void Delete(Product product)
        {
            orderServiceContext.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await orderServiceContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await orderServiceContext.Products.AsNoTracking().Where(product => product.id.Equals(productId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(ProductCategory productCategory)
        {
            return await orderServiceContext.Products.Where(product => product.category.Equals(productCategory)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByTitle(string title)
        {
            return await orderServiceContext.Products.Where(product => product.title.Equals(title)).ToListAsync();
        }

        public void Update(Product product)
        {
            orderServiceContext.Entry(product).State = EntityState.Modified;
        }
    }
}
