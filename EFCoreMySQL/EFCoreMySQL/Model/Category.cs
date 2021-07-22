using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Model
{
    public class Category
    {
        public int IDCategory { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        public List<Product> Products { get; set; }
    }
}
