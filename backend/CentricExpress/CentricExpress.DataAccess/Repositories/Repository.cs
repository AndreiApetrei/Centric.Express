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
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(AppDbContext appDbContext, ILogger<Repository<T>> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return ExecuteWithLogging(() => _appDbContext.Set<T>().Where(predicate).ToList());
        }

        public IEnumerable<T> Get()
        {
            return Get(x => true);
        }

        public T GetById(Guid id)
        {
            return ExecuteWithLogging(() => _appDbContext.Set<T>()
                .Find(id));
        }

        public void Insert(T entity)
        {
            ExecuteWithLogging(() => _appDbContext.Set<T>().Add(entity));
        }

        public void Update(T entity)
        {
            ExecuteWithLogging(() => _appDbContext.Set<T>().Update(entity));
        }

        public void Remove(Guid id)
        {
            var entity = GetById(id);
            ExecuteWithLogging(() => _appDbContext.Set<T>().Remove(entity));
        }

        public void SaveChanges()
        {
            ExecuteWithLogging(() => _appDbContext.SaveChanges());
        }

        private TResult ExecuteWithLogging<TResult>(Func<TResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Repository error!");
                throw;
            }
        }
    }
}
