using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    public class GroupedProducts
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public int ProductCount { get; set; }
        public IEnumerable<Product> Products{get;set; }
    }
}
