using System;

namespace CentricExpress.Business.Domain
{
    public class OrderLine
    {
        public OrderLine(Guid itemId, int quantity, Money itemPrice)
        {
            ItemId = itemId;
            Quantity = quantity;
            Price = itemPrice;
        }

        public Guid Id { get; set; }
        
        public int Quantity { get; private set; }
        public Money Price { get; set; }
        public Guid ItemId { get; private set; }
    }
}
