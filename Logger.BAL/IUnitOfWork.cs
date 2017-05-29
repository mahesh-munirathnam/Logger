using System;
using Logger.BAL.Interfaces;

namespace Logger.BAL
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IPermissionRepository Permissions { get; }
        IPersonPermissionRepository PersonPermissions { get; }

        int Complete();
    }
}
