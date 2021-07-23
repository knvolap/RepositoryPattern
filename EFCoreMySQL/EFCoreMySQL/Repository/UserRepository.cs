using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(MyDBContext context) : base(context)
        {
        }
    }
}
