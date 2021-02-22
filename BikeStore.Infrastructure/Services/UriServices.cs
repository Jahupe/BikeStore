using BikeStore.Core.QueryFilters;
using BikeStore.Infrastructure.Interfaces;
using System;

namespace BikeStore.Infrastructure.Services
{
    public class UriServices : IUriServices
    {
        private readonly string _baseUri;

        public UriServices(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetProductPaginationUri(ProductQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{ actionUrl}";
            return new Uri(baseUrl);
        }

    }
}
