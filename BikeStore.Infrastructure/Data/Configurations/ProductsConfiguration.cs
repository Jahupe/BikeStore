using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {

                builder.HasKey(e => e.id)
                    .HasName("PK__products__47027DF5FD292BB2");

                builder.ToTable("products", "production");

                builder.Property(e => e.id).HasColumnName("product_id");

                builder.Property(e => e.BrandId).HasColumnName("brand_id");

                builder.Property(e => e.CategoryId).HasColumnName("category_id");

                builder.Property(e => e.ListPrice)
                    .HasColumnName("list_price")
                    .HasColumnType("decimal(10, 2)");

                builder.Property(e => e.ModelYear).HasColumnName("model_year");

                builder.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__products__brand___36B12243");

                builder.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__products__catego__35BCFE0A");
        }
    }
}
