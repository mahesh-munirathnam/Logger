using Logger.DAL.Core;
using Logger.DAL.Domain;

namespace Logger.BAL.Interfaces
{
    public interface IPersonRepository: IRepository<Person>
    {
        Person ValidUser(string email, string password);
    }
}
