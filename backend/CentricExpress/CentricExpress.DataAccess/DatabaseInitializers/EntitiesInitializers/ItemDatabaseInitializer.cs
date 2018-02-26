using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.DataAccess.DatabaseInitializers.EnitiesIdentifiers;

namespace CentricExpress.DataAccess.DatabaseInitializers.EntitiesInitializers
{
    internal class ItemDatabaseInitializer
    {
        internal static void Seed(AppDbContext context)
        {
            if (context.Items.Any())
            {
                return;
            }

            var items = new List<Item> {
                new Item (ItemId.Item1)
                {
                    Description = "Item 1",
                    Price = new Money(38.9m, "RON")
                },
                new Item (ItemId.Item2)
                {
                Description = "Item 2",
                Price = new Money(42.5m, "RON")
                },
                new Item (ItemId.Item3)
                {
                    Description = "Item 3",
                    Price = new Money(104.3m, "RON")
                },
                new Item (ItemId.Item4)
                {
                    Description = "Item 4",
                    Price = new Money(55.2m, "RON")
                },
                new Item (ItemId.Item5)
                {
                    Description = "Item 5",
                    Price = new Money(12.7m, "RON")
                }
            };

            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
