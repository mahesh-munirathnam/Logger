using System;
using System.Linq;

namespace Tekinroads.DAL
{
    class PersonRepository 
    {
        private TekinroadsEntities personDB = new TekinroadsEntities();

       public void Update(Person entity)
        {
            Person foundModel =
                personDB.People
                .Where(a => a.PersonId.Equals(entity.PersonId))
                .FirstOrDefault();

            if (foundModel == null)
                throw new Exception("Model not found");

            foundModel.Name = entity.Name;
            personDB.People.Add(foundModel);
            personDB.SaveChanges();
        }

        public void Delete(byte Id)
        {
            Person foundModel =
                personDB.People
                .Where(a => a.PersonId.Equals(Id))
                .FirstOrDefault();

            if (foundModel == null)
                throw new Exception("Model not found");

            personDB.People.Remove(foundModel);
            personDB.SaveChanges();
        }

        public Person SelectOne(byte Id)
        {
            return personDB.People
                    .Where(a => a.PersonId.Equals(Id))
                    .FirstOrDefault();
        }

       
    }
}
