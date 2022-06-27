using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.id = Guid.NewGuid();
            product.created = DateTime.Now;
            product.updated = DateTime.Now;
            
            productRepository.Create(product);
            await productRepository.Commit();

            return product;
        }

        public async Task<Product> DeleteProduct(Guid productId)
        {
            var result = await productRepository.GetProductById(productId);
            productRepository.Delete(result);
            await productRepository.Commit();

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(ProductCategory productCategory)
        {
            return await productRepository.GetProductByCategory(productCategory);
        }

        public async Task<IEnumerable<Product>> GetProductByTitle(string productTitle)
        {
            return await productRepository.GetProductByTitle(productTitle);
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await productRepository.GetProductById(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            product.updated = DateTime.Now;
            productRepository.Update(product);
            await productRepository.Commit();
        }
    }
}
