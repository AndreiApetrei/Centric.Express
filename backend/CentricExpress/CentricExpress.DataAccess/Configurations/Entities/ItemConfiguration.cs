using System;
using CentricExpress.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentricExpress.DataAccess.Configurations.Entities
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(i => i.Id);
            
            builder.OwnsOne(i => i.Price, p =>
            {
                p.Property(amount => amount.Currency).HasColumnName("Currency");
                p.Property(amount => amount.Value).HasColumnName("Price");
            });
            
            builder.Property(i => i.Description).IsRequired().HasMaxLength(3000);
        }
    }
}
