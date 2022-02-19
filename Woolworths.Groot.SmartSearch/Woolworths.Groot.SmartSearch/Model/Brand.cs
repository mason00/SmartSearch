using MongoDB.Bson.Serialization.Attributes;

namespace Woolworths.Groot.SmartSearch.Model
{
    [BsonIgnoreExtraElements]
    public class Brand
    {
        public string BrandName { get; set; }
    }
}
