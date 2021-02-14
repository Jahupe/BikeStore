using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
                builder.HasKey(e => e.CustomerId)
                    .HasName("PK__customer__CD65CB850AA5B8DE");

                builder.ToTable("customers", "sales");

                builder.Property(e => e.CustomerId).HasColumnName("customer_id");

                builder.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(25)
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
