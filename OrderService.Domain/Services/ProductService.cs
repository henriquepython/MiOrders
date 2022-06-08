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
            return await productRepository.Create(product);
        }

        public async Task DeleteProduct(Guid productId)
        {
            var result = await productRepository.GetProductById(productId);
            await productRepository.Delete(result);
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await productRepository.GetAll();
        }

        public async Task<ICollection<Product>> GetProductByCategory(string productCategory)
        {
            return await productRepository.GetProductByCategory(productCategory);
        }

        public async Task<ICollection<Product>> GetProductByTitle(string productTitle)
        {
            return await productRepository.GetProductByCategory(productTitle);
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await productRepository.GetProductById(productId);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            product.created = DateTime.Now;
            await productRepository.Update(product);
            return product;
        }
    }
}
