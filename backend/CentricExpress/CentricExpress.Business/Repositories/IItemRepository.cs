using System;
using System.Collections.Generic;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        IDictionary<Guid, Money> GetPrices(IEnumerable<Guid> @select);
    }
}
