using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {

                builder.HasKey(e => e.OrderId)
                    .HasName("PK__orders__46596229C284C195");

                builder.ToTable("orders", "sales");

                builder.Property(e => e.OrderId).HasColumnName("order_id");

                builder.Property(e => e.CustomerId).HasColumnName("customer_id");

                builder.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                builder.Property(e => e.OrderStatus).HasColumnName("order_status");

                builder.Property(e => e.RequiredDate)
                    .HasColumnName("required_date")
                    .HasColumnType("date");

                builder.Property(e => e.ShippedDate)
                    .HasColumnName("shipped_date")
                    .HasColumnType("date");

                builder.Property(e => e.StaffId).HasColumnName("staff_id");

                builder.Property(e => e.StoreId).HasColumnName("store_id");

                builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__orders__customer__20C1E124");

                builder.HasOne(d => d.Staff)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__staff_id__22AA2996");

                builder.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__orders__store_id__21B6055D");
        }
    }
}
