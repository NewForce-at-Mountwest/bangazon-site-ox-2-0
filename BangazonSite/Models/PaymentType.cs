using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    public class PaymentType
    {
        
        public int PaymentTypeId { get; set; }
        
        public string Name { get; set; }
        [Display(Name= "Account Number")]
        public string acctNumber { get; set; }
        [Display(Name=" In Use")]
        public bool isActive { get; set; }
        public string UserId { get; set; }
        
        public ApplicationUser User { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
