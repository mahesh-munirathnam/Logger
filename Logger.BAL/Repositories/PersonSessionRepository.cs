using Logger.DAL.Domain;
using Logger.DAL.Core;
using Logger.BAL.Interfaces;
using System.Data.Entity;

namespace Logger.BAL.Repositories
{
    public class PersonSessionRepository : Repository<PersonSession>, IPersonSessionRepository
    {
        public PersonSessionRepository(DbContext context) : base(context)
        {
        }
    }
}
