using System;
using Tekinroads.BAL.Interfaces;

namespace Tekinroads.BAL
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IPermissionRepository Permissions { get; }
        IPersonPermissionRepository PersonPermissions { get; }

        int Complete();
    }
}
