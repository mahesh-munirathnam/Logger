using System.Data.Entity;
using Tekinroads.BAL.Interfaces;
using Tekinroads.DAL.Core;
using Tekinroads.DAL;

namespace Tekinroads.BAL.Repositories
{
    public class PersonPermissionRepository : Repository<PersonPermission>, IPersonPermissionRepository
    {
        public PersonPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
