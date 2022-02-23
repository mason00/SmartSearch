using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Woolworths.Groot.SmartSearch.Model
{
    [BsonIgnoreExtraElements]
    public class Brand
    {
        public ObjectId Id { get; set; }
        public string BrandName { get; set; }
        [BsonElement("highlight")]
        public HighLight[] HighLights { get; set; }
        [BsonElement("score")]
        public double Score { get; set; }
    }
}
