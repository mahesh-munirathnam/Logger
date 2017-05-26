using System.Data.Entity;
using Tekinroads.BAL.Interfaces;
using Tekinroads.DAL.Core;
using Tekinroads.DAL;
using System;

namespace Tekinroads.BAL.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public Person ValidUser(string email, string password)
        {
            return SingleOrDefault(p => p.Email == email && p.Password == password);
        }
    }
}
