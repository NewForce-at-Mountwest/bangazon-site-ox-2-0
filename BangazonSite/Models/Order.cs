using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted{ get; set; }        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
