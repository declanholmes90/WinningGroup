using MongoDB.Bson;

namespace WinningGroup.Core.Activity.Queries
{
    public class GetSummaryOfProductsViewModel
    {
        public IList<ProductDto> ProductCollection { get; set; }
    }

    public class ProductDto 
    {
        public ObjectId _id { get; set; }
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public AttributeDto Attribute { get; set; }
    }

    public class AttributeDto
    {
        public FantasticDto Fantastic { get; set; }
        public RatingDto Rating { get; set; }
    }

    public class RatingDto
    {
        public double Value { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class FantasticDto
    {
        public bool Value { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
    }
}
