using BikeStore.Core.QueryFilters;
using System;

namespace BikeStore.Infrastructure.Interfaces
{
    public interface IUriServices
    {
        Uri GetProductPaginationUri(ProductQueryFilter filter, string actionUrl);
    }
}