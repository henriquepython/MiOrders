using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);

        void Update(Order order);

        Order GetById(String id);

        IList<Order> GetAll();

        void Delete(Order order);

        void Commit();
    }
}
