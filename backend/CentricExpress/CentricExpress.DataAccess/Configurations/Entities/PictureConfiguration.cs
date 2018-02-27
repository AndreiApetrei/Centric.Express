using CentricExpress.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentricExpress.DataAccess.Configurations.Entities
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");

            builder.HasKey(i => i.Id);
            builder.Property(p => p.Description);
            builder.Property(p => p.Content).IsRequired();
        }
    }
}