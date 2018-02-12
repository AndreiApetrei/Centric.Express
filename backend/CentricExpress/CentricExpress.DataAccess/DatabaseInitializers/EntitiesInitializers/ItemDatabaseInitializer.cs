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
                new Item
                {
                    Id = ItemId.Item1,
                    Description = "Item 1",
                    Price = 38.9
                },
                new Item
                {
                Id = ItemId.Item2,
                Description = "Item 2",
                Price = 42.5
                },
                new Item
                {
                    Id = ItemId.Item3,
                    Description = "Item 3",
                    Price = 104.3
                },
                new Item
                {
                    Id = ItemId.Item4,
                    Description = "Item 4",
                    Price = 55.2
                },
                new Item
                {
                    Id = ItemId.Item5,
                    Description = "Item 5",
                    Price = 12.7
                }
            };

            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
