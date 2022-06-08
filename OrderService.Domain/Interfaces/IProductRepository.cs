using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);

        Task Update(Product product);

        Task<Product> GetProductById(Guid productId);

        Task<ICollection<Product>> GetProductByCategory(String productCategory);

        Task<ICollection<Product>> GetProductByTitle(String productTitle);

        Task<ICollection<Product>> GetAll();

        Task Delete(Product product);

        Task Commit();
    }
}
