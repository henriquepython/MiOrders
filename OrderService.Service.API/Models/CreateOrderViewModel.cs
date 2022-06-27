using OrderService.Domain.Models;

namespace OrderService.Service.API.Models
{
    public class CreateOrderViewModel
    {
        public Guid id { get; set; }

        public Guid userId { get; set; }

        public User? user { get; set; }

        public OrderStatus status { get; set; }

        public decimal totalPrice { get; set; }

    }
}
