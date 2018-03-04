using System;

namespace CentricExpress.Business.Domain
{
    public class OrderLine
    {
        public OrderLine(Guid itemId, int quantity, Money itemPrice)
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            Quantity = quantity;
            Price = itemPrice.Copy();
        }

        private OrderLine()
        {
            //orm
        }

        public Guid Id { get; private set; }
        
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
        public Guid ItemId { get; private set; }

        public Money Value => Price * Quantity;
    }
}
