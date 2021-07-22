using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MyDBContext context) : base(context)
        {
        }
       
    }
}
