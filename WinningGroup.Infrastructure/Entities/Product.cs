using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinningGroup.Infrastructure.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("sku")]
        public string Sku { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public double Price { get; set; }
        [BsonElement("attribute")]
        public Attribute Attribute { get; set; }
    }

    public class Attribute
    {
        [BsonElement("fantastic")]
        public Fantastic Fantastic { get; set; }
        [BsonElement("rating")]
        public Rating Rating { get; set; }
    }

    public class Rating
    {
        [BsonElement("value")]
        public double Value { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }

    public class Fantastic
    {
        [BsonElement("value")]
        public bool Value { get; set; }
        [BsonElement("type")]
        public int Type { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
