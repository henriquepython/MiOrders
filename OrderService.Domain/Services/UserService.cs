using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            user.id = Guid.NewGuid();
            user.created = DateTime.Now;
            user.roles = UserRoles.USER;

            userRepository.Create(user);
            await userRepository.Commit();
            return user;
        }

        public async Task<User> AdminCreateUser(User user)
        {
            user.id = Guid.NewGuid();
            user.created = DateTime.Now;
            user.roles = UserRoles.ADMIN;

            userRepository.Create(user);
            await userRepository.Commit();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userRepository.GetAll();
        }


        public async Task<User> GetById(Guid id)
        {
            return await userRepository.GetById(id);
        }
    }
}
