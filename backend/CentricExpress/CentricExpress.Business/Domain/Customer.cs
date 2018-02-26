using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class Customer : Aggregate
    {
        public Customer()
        {
            Id = Guid.NewGuid();
        }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
