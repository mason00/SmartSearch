using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Woolworths.Groot.SmartSearch.Model
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        public ObjectId Id { get; set; }
        [BsonElement("Stockcode")]
        public int Stockcode { get; set; }
        [BsonElement("GenericProductName")]
        public string Name { get; set; }
        [BsonElement("Brand")]
        public string Brand { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("highlight")]
        public HighLight[] HighLights { get; set; }
        [BsonElement("score")]
        public double Score { get; set; }
        [BsonElement("textScore")]
        public double FullTextScore { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class HighLight
    {
        [BsonElement("path")]
        public string Path { get; set; }
        [BsonElement("texts")]
        public Hit[] Texts { get; set; }
    }

    public class Hit
    {
        [BsonElement("value")]
        public string Value { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
    }
}