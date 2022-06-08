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

        Task<ICollection<Product>> GetAllProducts();

        Task<Product> GetProductById(Guid productId);

        Task<ICollection<Product>> GetProductByCategory(String productCategory);

        Task<ICollection<Product>> GetProductByTitle(String productTitle);

        Task<Product> UpdateProduct(Product product);

        Task DeleteProduct(Guid productId);


    }
}
