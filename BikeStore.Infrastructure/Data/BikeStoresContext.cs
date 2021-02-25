using BikeStore.Core.Data;
using BikeStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public virtual DbSet<Security> Securities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
