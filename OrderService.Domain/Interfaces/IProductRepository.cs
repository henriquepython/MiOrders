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

        Product GetByid(Guid id);

        ICollection<Product> GetAll();

        void Delete(Product product);

        void Commit();
    }
}
