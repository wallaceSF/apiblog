using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using apiblog.Context;
using apiblog.Interfaces;

namespace apiblog.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ContextData _context = null;
        DbSet<T> _DbSet;    

        public GenericRepository(ContextData context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _DbSet.Where(predicate);
            }

            return _DbSet.ToList();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public void Update(T entity)
        {            
            ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            _DbSet.Remove(entity);
        }

        public int Count()
        {
            return _DbSet.Count();
        }
    }
}