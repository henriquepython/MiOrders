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
        Product CreateProduct(Product product);

        List<Product> GetAllProducts();

        Product GetProductById(int id);

        Product GetProductByName(string name);

        Product GetProductByCategory(string category);

        Product UpdateProduct(Product product);

        void DeleteProduct(int id);


    }
}
