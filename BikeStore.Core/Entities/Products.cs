﻿using BikeStore.Core.Entities;
using System.Collections.Generic;

namespace BikeStore.Core.Data
{
    public partial class Products: BaseEntity
    {
        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
            Stocks = new HashSet<Stocks>();
        }

        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual Categories Category { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
    }
}
