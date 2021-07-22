using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Model
{
    public class Product
    {
        public int IDProduct { get; set; }
        public int IDCategory { get; set; }
        public string NameProduct { get; set; }
        public string MetaName { get; set; }
        public int? Quantity { get; set; }
        public double? UnitCost { get; set; } 
        public string Image { get; set; }
        public string Author { get; set; }     
        public string Description { get; set; }
        public bool? Status { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

       public Category Category { get; set; }
       public List<Order> Orders { get; set; }
    }
}
