using Logger.DAL.Core;
using Logger.DAL;

namespace Logger.BAL.Interfaces
{
    public interface IPersonRepository: IRepository<Person>
    {
        Person ValidUser(string email, string password);
    }
}
