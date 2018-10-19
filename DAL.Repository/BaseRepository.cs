using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        public readonly DbSet<T> dbSet;

        public BaseRepository(IDbContextFactory contextFactory)
        {
            _context = contextFactory.Create();
            dbSet = _context.Set<T>();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual T GetById(long id)
        {
            var query = _context.Set<T>().Find(id);
            return query;
        }

        public virtual T GetById(string id)
        {
            var query = _context.Set<T>().Find(id);
            return query;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Create()
        {
            var newEntity = _context.Set<T>().Create<T>();
            return newEntity;
        }

        public virtual async Task Save(T entity)
        {
            AttachEntity(entity);
            await SaveChanges();
        }

        public virtual async Task InsertBatch(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
           await SaveChanges();
        }

        public virtual async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
           await SaveChanges();
        }

        public virtual async Task Save(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                AttachEntity(entity);
            }

            await SaveChanges();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State != EntityState.Detached)
                {
                    _context.Set<T>().Remove(entity);
                }
            }
            await SaveChanges();
        }

        public virtual async Task Delete(Expression<Func<T, bool>> where)
        {
            var objects = _context.Set<T>().Where(where).AsEnumerable();
            foreach (var obj in objects)
            {
                _context.Set<T>().Remove(obj);
            }

            await SaveChanges();
        }

        public virtual IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual DbQuery<T> Include(Expression<Func<T, object>> path)
        {
            return (DbQuery<T>) this.dbSet.Include(path);
        }

        private async Task SaveChanges()
        {
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
            catch (ApplicationException ex)
            {
                System.Diagnostics.Debug.Write(ex);
                throw;
            }
        }

        private void AttachEntity(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
        }
    }
}
