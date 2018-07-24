using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL.Core;
using Logger.DAL.Domain;

namespace Logger.BAL.Repositories
{
    public class WorkoutRepository : Repository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(DbContext context) : base(context)
        {
        }

    }
}
