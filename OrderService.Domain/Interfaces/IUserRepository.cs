using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);

        void Update(User user);

        Task<IEnumerable<User>> GetAll();

        void Delete(User user);

        Task Commit();

        Task<User> GetById(Guid id);
    }
}
