using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class Order : Aggregate
    {
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
