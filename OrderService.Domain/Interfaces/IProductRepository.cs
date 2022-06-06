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

        Product GetByid(String id);

        void Delete(Product product);
    }
}
