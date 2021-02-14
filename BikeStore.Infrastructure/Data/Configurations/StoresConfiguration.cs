using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class StoresConfiguration : IEntityTypeConfiguration<Stores>
    {
        public void Configure(EntityTypeBuilder<Stores> builder)
        {

                builder.HasKey(e => e.StoreId)
                    .HasName("PK__stores__A2F2A30C57A70CC7");

                builder.ToTable("stores", "sales");

                builder.Property(e => e.StoreId).HasColumnName("store_id");

                builder.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.StoreName)
                    .IsRequired()
                    .HasColumnName("store_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasMaxLength(5)
                    .IsUnicode(false);
        }
    }
}
