using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Models
{
    public class Cart
    {
        public Guid id { get; set; }

        public Guid? userId { get; set; }

        public int quantity { get; set; }
       
        public decimal price { get; set; }

        public string? title { get; set; }

        public string? image { get; set; }

    }
}
