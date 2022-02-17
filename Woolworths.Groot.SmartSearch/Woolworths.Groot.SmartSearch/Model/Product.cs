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
    }
}