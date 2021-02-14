using BikeStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure.Data.Configurations
{
    public class StocksConfiguration : IEntityTypeConfiguration<Stocks>
    {
        public void Configure(EntityTypeBuilder<Stocks> builder)
        {

                builder.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__stocks__E68284D3BB8DAC3A");

                builder.ToTable("stocks", "production");

                builder.Property(e => e.StoreId).HasColumnName("store_id");

                builder.Property(e => e.ProductId).HasColumnName("product_id");

                builder.Property(e => e.Quantity).HasColumnName("quantity");

                builder.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__stocks__product___3F466844");

                builder.HasOne(d => d.Store)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__stocks__store_id__3E52440B");

        }
    }
}
