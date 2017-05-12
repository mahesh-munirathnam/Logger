using System.Linq;

namespace Tekinroads.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Save(); 
    }
}
