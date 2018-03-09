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

            var customers = new List<Customer> {
                new Customer(Guid.Parse("12a079e3-f6a7-4c2c-b575-bb01e3372683"))
                {
                    Age = 35, FirstName = "Dummy", Surname = "User"
                },
                new Customer(Guid.Parse("4ca88471-c4f6-4635-b3af-c020721d7c18"))
                {
                    Age = 17, FirstName = "Sir", Surname = "John"
                },
                new Customer(Guid.Parse("fb0cc4f5-f5b6-4ccb-b07d-2c198ddb0c49"))
                {
                    Age = 24, FirstName = "Rock", Surname = "Solid"
                },
                new Customer(Guid.Parse("c5facd1f-b346-4ee2-8f6d-3d56a2da78fd"))
                {
                    Age = 30, FirstName = "Super", Surname = "Dummy"
                },
                new Customer(Guid.Parse("af3c7769-31c9-4ed0-a7d5-1b9fc27041c9"))
                {
                    Age = 31, FirstName = "Jane", Surname = "Darc"
                }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}