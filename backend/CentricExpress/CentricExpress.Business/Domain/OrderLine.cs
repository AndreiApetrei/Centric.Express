using System;

namespace CentricExpress.Business.Domain
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid ItemId { get; set; }
    }
}
