using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace apiblog.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null);
        T Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count();
    }
}
