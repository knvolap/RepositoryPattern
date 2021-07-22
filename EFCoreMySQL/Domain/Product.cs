using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class Product
    {   
    public int Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public int UserGroupId { get; set; } 
    public DateTime CreationDateTime { get; set; } 
    public DateTime? LastUpdateDateTime { get; set; }
    }

}

