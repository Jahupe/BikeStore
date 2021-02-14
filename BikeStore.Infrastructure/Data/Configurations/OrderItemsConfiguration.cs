using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {

                builder.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("PK__order_it__837942D4E42BDC5E");

                builder.ToTable("order_items", "sales");

                builder.Property(e => e.OrderId).HasColumnName("order_id");

                builder.Property(e => e.ItemId).HasColumnName("item_id");

                builder.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(4, 2)");

                builder.Property(e => e.ListPrice)
                    .HasColumnName("list_price")
                    .HasColumnType("decimal(10, 2)");

                builder.Property(e => e.ProductId).HasColumnName("product_id");

                builder.Property(e => e.Quantity).HasColumnName("quantity");

                builder.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_ite__order__3A81B327");

                builder.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__order_ite__produ__3B75D760");
        }
    }
}
