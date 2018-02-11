using System;

namespace CentricExpress.Business.Domain
{
    public class Item : IAggregate
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Picture { get; set; }
        public virtual OrderLine OrderLine { get; set; }
    }
}
