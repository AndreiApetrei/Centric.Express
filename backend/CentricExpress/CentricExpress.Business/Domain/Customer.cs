using System;

namespace CentricExpress.Business.Domain
{
    public class Customer : Aggregate
    {
        public Customer() : this(Guid.NewGuid())
        {
            //orm
        }

        public Customer(Guid id)
        {
            Id = id;
        }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public string FullName => $"{FirstName} {Surname}";
    }
}