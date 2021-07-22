using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository
{
    public class OderRepository :GenericRepository<Oder>
    {
        public OderRepository(MyDBContext context) : base(context)
        {
        }

    }
}
