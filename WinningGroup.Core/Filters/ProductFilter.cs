using MongoDB.Driver;
using WinningGroup.Core.Activity.Queries;
using WinningGroup.Infrastructure.Entities;

namespace WinningGroup.Core.Filters
{
    public static class ProductFilter
    {
        public static FilterDefinition<Product> GetFilter(GetSummaryOfProductsQuery query)
        {
            var builder = Builders<Product>.Filter;

            FilterDefinition<Product> filter = Builders<Product>.Filter.Empty;

            if (query == null)
            {
                return Builders<Product>.Filter.Empty;
            }

            if(query.PriceMin.HasValue)
            {
                filter &= builder.Gte(p => p.Price, query.PriceMin.Value);
            }
            if (query.PriceMax.HasValue)
            {
                filter &= builder.Lte(p => p.Price, query.PriceMax.Value);
            }
            if (query.IsFantastic.HasValue)
            {
                filter &= builder.Eq(p => p.Attribute.Fantastic.Value, query.IsFantastic);
            }
            if(query.RatingMin.HasValue)
            {
                filter &= builder.Gte(p => p.Attribute.Rating.Value, query.RatingMin);
            }
            if (query.RatingMax.HasValue)
            {
                filter &= builder.Lte(p => p.Attribute.Rating.Value, query.RatingMax);
            }

            return filter;
        }
    }
}
