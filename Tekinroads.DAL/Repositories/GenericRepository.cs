using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace Tekinroads.DAL
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class  {
    private TekinRoadsEntities _entities = new TekinRoadsEntities();
   

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

