using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository
{
    public class UserGroupRepository : GenericRepository<UserGroup>
    {
        public UserGroupRepository(MyDBContext context) : base(context)
        {
        }
    }
}
