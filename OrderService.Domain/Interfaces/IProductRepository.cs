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
        void Create(Product product);

        void Update(Product product);

        Task<Product> GetProductById(Guid productId);

        Task<IEnumerable<Product>> GetProductByCategory(ProductCategory productCategory);

        Task<IEnumerable<Product>> GetProductByTitle(string productTitle);

        Task<IEnumerable<Product>> GetAll();

        void Delete(Product product);

        Task Commit();
    }
}
