using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CentricExpress.DataAccess.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext appDbContext, ILogger<Repository<Item>> logger)
            : base(appDbContext, logger) { }
    }
}
