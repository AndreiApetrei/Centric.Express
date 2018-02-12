using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Repositories
{
    public interface IRepository<T> where T : Aggregate
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Get();

        T GetById(Guid id);

        void Insert(T entity);

        void Update(T entity);

        void Remove(Guid id);

        void SaveChanges();
    }
}
