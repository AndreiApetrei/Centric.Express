using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class ItemPrices
    {
        private IDictionary<Guid, Money> Prices { get; }

        public ItemPrices(IDictionary<Guid, Money> prices)
        {
            Prices = prices;
        }

        public ItemPrices() : this(new Dictionary<Guid, Money>())
        {
        }

        public ItemPrices WithPrice(Guid itemId, Money price)
        {
            Prices.Add(itemId, price);
            return this;
        }

        public Money GetPrice(Guid itemId)
        {
            if (!Prices.ContainsKey(itemId))
            {
                throw new ArgumentException(string.Format("We dont have a price for item with id {0}", itemId));
            }
            
            return !Prices.ContainsKey(itemId) ? Money.Zero : Prices[itemId];
        }
    }
}