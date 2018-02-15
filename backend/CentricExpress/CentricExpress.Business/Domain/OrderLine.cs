using System;

namespace CentricExpress.Business.Domain
{
    public class OrderLine : Aggregate
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid ItemId { get; set; }
    }
}
