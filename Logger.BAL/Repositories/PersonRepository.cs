using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL.Core;
using Logger.DAL;
using System;

namespace Logger.BAL.Repositories
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
