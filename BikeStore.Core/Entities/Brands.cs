using BikeStore.Core.Entities;
using System.Collections.Generic;
namespace BikeStore.Core.Data
{
    public partial class Brands :BaseEntity
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        //public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
