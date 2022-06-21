using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Models;
using OrderService.Infra.Data.Mapper;

namespace OrderService.Infra.Data.Context
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        public OrderServiceContext(DbContextOptions<OrderServiceContext> dbContextOptions)
                : base(dbContextOptions)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CartMap());
            modelBuilder.ApplyConfiguration(new UserMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
