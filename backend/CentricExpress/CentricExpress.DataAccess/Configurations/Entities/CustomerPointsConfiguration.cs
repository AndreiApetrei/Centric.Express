using CentricExpress.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentricExpress.DataAccess.Configurations.Entities
{
    public class CustomerPointsConfiguration : IEntityTypeConfiguration<CustomerPoints>
    {
        public void Configure(EntityTypeBuilder<CustomerPoints> builder)
        {
            builder.ToTable("Points");
            
            builder.HasKey(o => o.OrderId);
            builder.Property(points => points.CustomerId);
            builder.Property(points => points.Points);
        }
    }
}