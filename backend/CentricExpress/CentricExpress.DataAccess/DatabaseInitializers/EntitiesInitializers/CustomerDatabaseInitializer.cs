using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;

namespace CentricExpress.DataAccess.DatabaseInitializers.EntitiesInitializers
{
    internal class CustomerDatabaseInitializer
    {
        internal static void Seed(AppDbContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            var items = new List<Customer> {
                new Customer()
                {
                    Age = 35, FirstName = "Dummy", Surname = "User"
                },
            };

            context.Customers.AddRange(items);
            context.SaveChanges();
        }
    }
}