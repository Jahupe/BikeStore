﻿using BikeStore.Core.Data;
using BikeStore.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Infrastructure.Data
{
    public partial class BikeStoresContext : DbContext
    {
        public BikeStoresContext()
        {
        }

        public BikeStoresContext(DbContextOptions<BikeStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandsConfiguration());

            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());

            modelBuilder.ApplyConfiguration(new CustomersConfiguration());

            modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());

            modelBuilder.ApplyConfiguration(new OrdersConfiguration());

            modelBuilder.ApplyConfiguration(new ProductsConfiguration());

            modelBuilder.ApplyConfiguration(new StaffsConfiguration());

            modelBuilder.ApplyConfiguration(new StocksConfiguration());

            modelBuilder.ApplyConfiguration(new StoresConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
