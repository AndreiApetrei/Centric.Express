using CentricExpress.Business.Domain;
using CentricExpress.DataAccess.Configurations.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentricExpress.DataAccess
{
    public class AppDbContext
        : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLine { get; set; }
        
        public DbSet<Picture> Pictures { get; set; }
        
        public DbSet<CustomerPoints> CustomerPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("config");
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerPointsConfiguration());
        }
    }
}