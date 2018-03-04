using CentricExpress.Business.Repositories;

namespace CentricExpress.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Commit()
        {
            appDbContext.SaveChanges();
        }
    }
}