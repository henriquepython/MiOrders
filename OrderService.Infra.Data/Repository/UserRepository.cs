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

        public void Commit()
        {
            orderServiceContext.SaveChanges();
        }

        public void Create(User user)
        {
            orderServiceContext.Users.Add(user);
        }

        public void Delete(User user)
        {
            orderServiceContext.Users.Remove(user);
        }

        public IList<User> GetAll()
        {
            return orderServiceContext.Users.AsNoTracking().ToList();
        }

        public User GetById(String id)
        {
            return orderServiceContext.Users.AsNoTracking().FirstOrDefault(x => x.id.Equals(id));
        }

        public void Update(User user)
        {
            orderServiceContext.Users.Update(user);
        }
    }
}
