using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Core.QueryFilters
{
    public class ProductQueryFilter
    {
        public string product_name { get; set; }
        public int? brand_id { get; set; }
        public int? category_id { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
