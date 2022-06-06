using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Models
{
    public class User
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public int phoneNumber { get; set; }

        public UserRoles roles { get; set; }

        public DateTime created { get; set; }
    }
}
