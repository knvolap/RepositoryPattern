using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Model
{
    public class Order
    {
        public int IDOder { get; set; }

        public int IDProduct { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public int? Quantity { get; set; }
        public double? Amount { get; set; }
        public DateTime DayBuy { get; set; }
        public string Address { get; set; }
        public bool? Status { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public Product Product { get; set; }
    }
}
