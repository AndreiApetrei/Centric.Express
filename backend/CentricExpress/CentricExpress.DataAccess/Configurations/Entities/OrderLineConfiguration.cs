using CentricExpress.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentricExpress.DataAccess.Configurations.Entities
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLine");
            builder.HasKey(ol => ol.Id);
            builder.Property(ol => ol.Price).IsRequired();
            builder.Property(ol => ol.Quantity).IsRequired();
            builder.Property(ol => ol.ItemId).IsRequired();
        }
    }
}
