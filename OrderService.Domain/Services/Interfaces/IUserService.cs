using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Models;

namespace OrderService.Domain.Interfaces
{
    public interface IUserService
    { 
        Task<User> CreateUser(User user);

        Task<User> AdminCreateUser(User user);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetById(Guid id);
    }
}
