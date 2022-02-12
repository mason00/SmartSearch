using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Woolworths.Groot.SmartSearch.Model
{
    [BsonIgnoreExtraElements]
    public class Rent
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
    }
}
