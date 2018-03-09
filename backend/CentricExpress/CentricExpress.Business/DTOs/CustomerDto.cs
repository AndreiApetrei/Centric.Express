using CentricExpress.Business.Domain;
using System;

namespace CentricExpress.Business.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public static CustomerDto FromDomain(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Age = customer.Age
            };
        }

        public Customer ToDomain()
        {
            return new Customer(Id)
            {
                Age = Age,
                FirstName = FullName.Split(' ')[0],
                Surname = FullName.Split(' ')[1]
            };
        }
    }
}
