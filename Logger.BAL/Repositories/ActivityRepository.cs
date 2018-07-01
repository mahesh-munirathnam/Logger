using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL.Core;
using Logger.DAL;

namespace Logger.BAL.Repositories
{
    public class ActivityRepository : Repository<Activity>,IActivityRepository
    {
        public ActivityRepository(DbContext context) : base(context)
        {
        }

    }
}
