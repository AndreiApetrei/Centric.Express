using System.Collections.Generic;
using System.Linq;

using CentricExpress.Business.Domain;
using CentricExpress.DataAccess.DatabaseInitializers.EntitiesIdentifiers;

namespace CentricExpress.DataAccess.DatabaseInitializers.EntitiesInitializers
{
    internal static class ItemDatabaseInitializer
    {
        internal static void Seed(AppDbContext context)
        {
            if (context.Items.Any())
            {
                return;
            }

            var items = new List<Item>()
                        {
                            new Item
                            {
                                Id = ItemId.Item1,
                                Description = "Item 1",
                                Price = new Money(40m, "RON")
                            },
                            new Item
                            {
                                Id = ItemId.Item2,
                                Description = "Item 2",
                                Price = new Money(65m, "RON")
                            }
                        };

            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
