using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class StaffsConfiguration : IEntityTypeConfiguration<Staffs>
    {
        public void Configure(EntityTypeBuilder<Staffs> builder)
        {

                builder.HasKey(e => e.StaffId)
                    .HasName("PK__staffs__1963DD9C8197F302");

                builder.ToTable("staffs", "sales");

                builder.HasIndex(e => e.Email)
                    .HasName("UQ__staffs__AB6E616402527496")
                    .IsUnique();

                builder.Property(e => e.StaffId).HasColumnName("staff_id");

                builder.Property(e => e.Active).HasColumnName("active");

                builder.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.ManagerId).HasColumnName("manager_id");

                builder.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.StoreId).HasColumnName("store_id");

                builder.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__staffs__manager___145C0A3F");

                builder.HasOne(d => d.Store)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__staffs__store_id__1367E606");
        }
    }
}
