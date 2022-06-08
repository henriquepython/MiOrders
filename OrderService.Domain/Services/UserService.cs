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

            return await userRepository.Create(user);
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await userRepository.GetAll();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userRepository.GetUserByEmail(email);
        }
    }
}
