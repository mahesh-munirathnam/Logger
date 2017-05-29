using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL.Core;
using Logger.DAL;

namespace Logger.BAL.Repositories
{
    public class PersonPermissionRepository : Repository<PersonPermission>, IPersonPermissionRepository
    {
        public PersonPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
