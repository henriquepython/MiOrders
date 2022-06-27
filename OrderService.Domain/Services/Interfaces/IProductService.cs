using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IProductService
    { 
        Task<Product> CreateProduct(Product product);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(Guid productId);

        Task<IEnumerable<Product>> GetProductByCategory(ProductCategory productCategory);

        Task<IEnumerable<Product>> GetProductByTitle(string productTitle);

        Task UpdateProduct(Product product);

        Task<Product> DeleteProduct(Guid productId);


    }
}
