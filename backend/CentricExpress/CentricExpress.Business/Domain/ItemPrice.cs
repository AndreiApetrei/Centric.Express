using System;

namespace CentricExpress.Business.Domain
{
    public class ItemPrice
    {
        public Guid ItemId { get; }
        public Money Price { get; }

        public ItemPrice(Guid itemId, Money price)
        {
            ItemId = itemId;
            Price = price;
        }
    }
}