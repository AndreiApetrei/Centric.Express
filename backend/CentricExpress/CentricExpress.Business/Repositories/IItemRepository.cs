using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        ItemPrices GetPrices(params Guid[] itemIds);
        void PrepareForUpdate(Money itemPrice);
        void UpdateItem(Item item);
    }
}
