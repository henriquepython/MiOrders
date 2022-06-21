using OrderService.Domain.Models;

namespace OrderService.Service.API.Models
{
    public class CreateProductViewModel
    {
        public string title { get; set; }

        public string image { get; set; }

        public string description { get; set; }

        public ProductCategory category { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }
    }
}
