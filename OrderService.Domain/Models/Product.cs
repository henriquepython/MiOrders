using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Models
{
    public class Product
    {
        public Guid id { get; set; }
        public string title { get; set; }

        public string image { get; set; }

        public string description { get; set; }

        public ProductCategory category { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public DateTime created { get; set; }
    }
}
