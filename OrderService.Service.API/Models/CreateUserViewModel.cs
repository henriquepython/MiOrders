using System.ComponentModel.DataAnnotations;
using OrderService.Domain.Models;

namespace OrderService.Service.API.Models
{
    public class CreateUserViewModel
    {
        public string name { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public string password { get; set; }
    }
}
