using CentricExpress.DataAccess.DatabaseInitializers.EntitiesInitializers;

namespace CentricExpress.DataAccess.DatabaseInitializers
{
    public static class DatabaseInitializer
    {
        public static void Seed(AppDbContext context)
        {
            //create database and seed data on the first run.
            //context.Database.EnsureCreated(); 

            ItemDatabaseInitializer.Seed(context);
            CustomerDatabaseInitializer.Seed(context);
        }
    }
}
