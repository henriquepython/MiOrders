using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Infra.Data.Context;

namespace OrderService.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OrderServiceContext orderServiceContext;

        public UserRepository(OrderServiceContext orderServiceContext)
        {
            this.orderServiceContext = orderServiceContext;
        }

        public async Task Commit()
        {
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task<User> Create(User user)
        {
            orderServiceContext.Users.Add(user);
            await orderServiceContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(User user)
        {
            orderServiceContext.Users.Remove(user);
            await orderServiceContext.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await orderServiceContext.Users.Include(prop => prop.carts).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await orderServiceContext.Users.AsNoTracking().Where(user => user.email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            orderServiceContext.Users.Update(user);
            await orderServiceContext.SaveChangesAsync();
        }
    }
}
