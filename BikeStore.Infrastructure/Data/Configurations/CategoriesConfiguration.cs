using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {            
                builder.HasKey(e => e.CategoryId)
                    .HasName("PK__categori__D54EE9B4AB048D77");

                builder.ToTable("categories", "production");

                builder.Property(e => e.CategoryId).HasColumnName("category_id");

                builder.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
        }
    }
}
