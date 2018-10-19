using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(long id);
        T GetById(string id);
        IQueryable<T> GetAll();
        Task Delete(T entity);
        Task Delete(Expression<Func<T, bool>> where);
        Task Delete(IEnumerable<T> entities);
        Task Save(T entity);
        Task Save(IEnumerable<T> entities);
        Task InsertBatch(IEnumerable<T> entities);
        Task Insert(T entity);
        T Create();
        Task Update(T entity);
        IEnumerable<T> Find(Func<T, bool> predicate);
        DbQuery<T> Include(Expression<Func<T, object>> path);
    }
}
