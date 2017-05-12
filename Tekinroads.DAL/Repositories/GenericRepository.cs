using System.Linq;
using Tekinroads.DAL;

namespace Tekinroads.DAL
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class  {
    private TekinroadsEntities _entities = new TekinroadsEntities();
   

    public virtual IQueryable<T> GetAll() {

        IQueryable<T> query = _entities.Set<T>();
        return query;
    }

    public virtual void Add(T entity) {
        _entities.Set<T>().Add(entity);
    }

    public virtual void Delete(T entity) {
        _entities.Set<T>().Remove(entity);
    }

   public virtual void Save() {
        _entities.SaveChanges();
    }
}

}

