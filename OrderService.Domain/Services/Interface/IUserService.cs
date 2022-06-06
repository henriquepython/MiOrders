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
        User CreateUser(User user);

        List<User> GetAllUsers();

        User GetUserByEmail(String email);
    }
}
