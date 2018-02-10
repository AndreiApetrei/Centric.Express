using System;
using System.Collections;
using System.Collections.Generic;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Repositories
{
    public interface IRepository<T> where T : IAggregate
    {
        ICollection<T> Get();

        T GetById(Guid id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(Guid id);
    }
}
