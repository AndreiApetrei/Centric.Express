using System;
using System.Collections.Generic;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using Microsoft.Extensions.Logging;

namespace CentricExpress.DataAccess.Repositories
{
    class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext appDbContext, ILogger<Repository<Item>> logger) : base(appDbContext, logger)
        {
        }

        public IList<ItemPrice> GetPrices(IEnumerable<Guid> @select)
        {
            throw new NotImplementedException();
        }
    }
}