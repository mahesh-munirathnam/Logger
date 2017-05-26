using Tekinroads.DAL.Core;
using Tekinroads.DAL;

namespace Tekinroads.BAL.Interfaces
{
    public interface IPersonRepository: IRepository<Person>
    {
        Person ValidUser(string email, string password);
    }
}
