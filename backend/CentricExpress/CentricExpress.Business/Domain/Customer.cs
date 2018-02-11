using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class Customer : IAggregate
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
