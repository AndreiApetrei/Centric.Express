using System;
using System.Collections.Generic;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;

namespace CentricExpress.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : IAggregate
    {
        public ICollection<T> Get()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
