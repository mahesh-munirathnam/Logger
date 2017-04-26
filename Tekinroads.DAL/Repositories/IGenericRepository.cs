using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Tekinroads.DomainModel
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Save(); 
    }
}
