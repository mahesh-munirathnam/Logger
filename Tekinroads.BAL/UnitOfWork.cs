using Logger.BAL.Interfaces;
using Logger.BAL.Repositories;
using Logger.DAL;

namespace Logger.BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBEntities _context;

        public UnitOfWork(DBEntities context)
        {
            _context = context;
            Persons = new PersonRepository(_context);
            Permissions = new PermissionRepository(_context);
            PersonPermissions = new PersonPermissionRepository(_context);
        }

        public IPersonRepository Persons { get; private set; }
        public IPermissionRepository Permissions { get; private set; }
        public IPersonPermissionRepository PersonPermissions { get; private set; }

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
