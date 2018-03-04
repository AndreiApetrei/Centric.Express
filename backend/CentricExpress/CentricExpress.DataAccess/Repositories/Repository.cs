using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using Microsoft.Extensions.Logging;

namespace CentricExpress.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : Aggregate
    {
        protected readonly AppDbContext AppDbContext;
        private readonly ILogger<Repository<T>> logger;

        public Repository(AppDbContext appDbContext, ILogger<Repository<T>> logger)
        {
            AppDbContext = appDbContext;
            this.logger = logger;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return ExecuteWithLogging(() => AppDbContext.Set<T>().Where(predicate).ToList());
        }

        public IEnumerable<T> Get()
        {
            return Get(x => true);
        }

        public T GetById(Guid id)
        {
            return ExecuteWithLogging(() => AppDbContext.Set<T>()
                .Find(id));
        }

        public void Insert(T entity)
        {
            ExecuteWithLogging(() => AppDbContext.Set<T>().Add(entity));
        }

        public void Update(T entity)
        {
            ExecuteWithLogging(() => AppDbContext.Set<T>().Update(entity));
        }

        public void Remove(Guid id)
        {
            var entity = GetById(id);
            ExecuteWithLogging(() => AppDbContext.Set<T>().Remove(entity));
        }

        public void SaveChanges()
        {
            ExecuteWithLogging(() => AppDbContext.SaveChanges());
        }

        protected TResult ExecuteWithLogging<TResult>(Func<TResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Repository error!");
                throw;
            }
        }
    }
}
