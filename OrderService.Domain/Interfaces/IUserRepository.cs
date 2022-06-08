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
        Task<User> Create(User user);

        Task Update(User user);

        Task<ICollection<User>> GetAll();

        Task Delete(User user);

        Task Commit();
        Task<User> GetUserByEmail(string email);
    }
}
