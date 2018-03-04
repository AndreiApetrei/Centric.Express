using System;
using System.Collections.Generic;
using System.Linq;
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

        public ItemPrices GetPrices(params Guid[] itemIds)
        {
            return ExecuteWithLogging(() =>
                new ItemPrices(AppDbContext.Set<Item>().Where(item => itemIds.Contains(item.Id))
                    .ToDictionary(item => item.Id, item => item.Price)));
        }
    }
}