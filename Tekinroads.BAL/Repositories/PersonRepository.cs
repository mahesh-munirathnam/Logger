using System.Data.Entity;
using Tekinroads.BAL.Interfaces;
using Tekinroads.DAL.Core;
using Tekinroads.DAL.Domain;

namespace Tekinroads.BAL.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
