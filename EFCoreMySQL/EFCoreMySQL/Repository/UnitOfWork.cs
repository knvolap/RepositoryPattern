using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _context;
        public UnitOfWork(MyDBContext context)
        {
            _context = context;
            //Developers = new CategoryRepository(_context);
            //Projects = new ProjectRepository(_context);
        }
        public ICategoryRepository Developers { get; private set; }

        public ICategoryRepository Category => throw new NotImplementedException();

        //public IProjectRepository Projects { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}