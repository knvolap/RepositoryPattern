using EFCoreMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository.Interface
{
    interface IUserRepository: IGenericRepository<User>
    {
    }
}
