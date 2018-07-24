using Logger.BAL.Interfaces;
using Logger.BAL.Repositories;
using Logger.DAL.Domain;

namespace Logger.BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBEntities _context;

        public UnitOfWork(DBEntities context)
        {
            _context = context;
            People = new PersonRepository(_context);
            Permissions = new PermissionRepository(_context);
            PersonPermissions = new PersonPermissionRepository(_context);
            Transactions = new TransactionRepository(_context);
            Activities = new ActivityRepository(_context);
            Workouts = new WorkoutRepository(_context);
        }

        public IPersonRepository People { get; private set; }
        public IPermissionRepository Permissions { get; private set; }
        public IPersonPermissionRepository PersonPermissions { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public IActivityRepository Activities { get; private set; }
        public IWorkoutRepository Workouts { get; private set; }

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
