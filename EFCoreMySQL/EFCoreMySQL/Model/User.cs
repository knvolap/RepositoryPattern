using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int UserGroupId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
