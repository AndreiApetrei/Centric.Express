using CentricExpress.Business.Domain;
using CentricExpress.DataAccess.Configurations.Entities;

using Microsoft.EntityFrameworkCore;

namespace CentricExpress.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("express");
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
