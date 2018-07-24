using System;
using Logger.BAL.Interfaces;

namespace Logger.BAL
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository People { get; }
        IPermissionRepository Permissions { get; }
        IPersonPermissionRepository PersonPermissions { get; }
        ITransactionRepository Transactions { get; }
        IWorkoutRepository Workouts { get; }
        IActivityRepository Activities { get; }

        int Complete();
    }
}
