using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICollection<User> GetAll()
        {
            return orderServiceContext.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return orderServiceContext.Users.FirstOrDefault(x => x.id.Equals(id));
        }

        public void Update(User user)
        {
           
        }
    }
}
