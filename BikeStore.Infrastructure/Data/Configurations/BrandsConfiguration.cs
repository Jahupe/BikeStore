using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class BrandsConfiguration : IEntityTypeConfiguration<Brands>
    {
        public void Configure(EntityTypeBuilder<Brands> builder)
        {

                builder.HasKey(e => e.BrandId)
                    .HasName("PK__brands__5E5A8E27B2C0FE0D");

                builder.ToTable("brands", "production");

                builder.Property(e => e.BrandId).HasColumnName("brand_id");

                builder.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
        }
    }
}
