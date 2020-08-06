using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinalProject.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate); //ham tra ve true hoac false
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
