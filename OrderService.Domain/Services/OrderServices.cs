using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICartRepository cartRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
        }
        public async Task CancelOrder(Guid id)
        {
            Order order = await orderRepository.GetById(id);
            order.status = OrderStatus.Cancel;
            await orderRepository.Commit();
        }

        public async Task CompletedOrder(Guid id)
        {
            Order order = await orderRepository.GetById(id);
            order.status = OrderStatus.Completed;
            await orderRepository.Commit();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.id = Guid.NewGuid();
            order.createdDate = DateTime.Now;
            order.status = OrderStatus.Pending;
            order.totalPrice = 0;

            var orderCart = await orderRepository.GetCartByUser(order.userId);

            foreach (var orderItem in orderCart)
            {
                var total = orderItem.quantity * orderItem.price;
                order.totalPrice += total;
            }

            await orderRepository.Create(order);
            return order;

        }
        
        public async Task<ICollection<Order>> findAll()
        {
            return await orderRepository.GetAll();
        }

        public async Task<ICollection<Order>> FindOrderByUser(Guid userId)
        {
            return await orderRepository.FindOrderByUser(userId);
        }

        public async Task RequestCancelOrder(Guid id)
        {
            Order order = await orderRepository.GetById(id);
            order.status = OrderStatus.RequestCancelled;
            await orderRepository.Commit();
        }
    }
}
