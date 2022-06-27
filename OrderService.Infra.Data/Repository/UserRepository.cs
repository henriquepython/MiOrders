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

        public void Create(User user)
        {
            orderServiceContext.Users.Add(user);
        }

        public void Delete(User user)
        {
            orderServiceContext.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await orderServiceContext.Users.AsNoTracking().Include(prop => prop.carts).ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await orderServiceContext.Users.Where(user => user.id == id).Include(prop => prop.carts).FirstOrDefaultAsync();
        }

        public void Update(User user)
        {
            orderServiceContext.Entry(user).State = EntityState.Modified;
        }
    }
}
