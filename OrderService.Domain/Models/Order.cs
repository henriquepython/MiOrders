using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Models
{
    public class Order
    {
        public Guid id { get; set; }

        public Guid userId { get; set; }

        public User? user { get; set; }

        public OrderStatus status { get; set; }

        public decimal totalPrice { get; set; }

        public DateTime createdDate { get; set; }

    }
}
