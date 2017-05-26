using System.Data.Entity;
using Tekinroads.BAL.Interfaces;
using Tekinroads.DAL.Core;
using Tekinroads.DAL;

namespace Tekinroads.BAL.Repositories
{
    public class PermissionRepository : Repository<Permission>,IPermissionRepository
    {
        public PermissionRepository(DbContext context) : base(context)
        {
        }

    }
}
