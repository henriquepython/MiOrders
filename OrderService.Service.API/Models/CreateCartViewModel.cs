using OrderService.Domain.Models;

namespace OrderService.Service.API.Models
{
    public class CreateCartViewModel
    {
        public Guid userId { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public string title { get; set; }

        public string image { get; set; }
    }
}
