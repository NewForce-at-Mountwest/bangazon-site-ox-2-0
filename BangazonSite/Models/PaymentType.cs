using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public string acctNumber { get; set; }
        public bool isActive { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
