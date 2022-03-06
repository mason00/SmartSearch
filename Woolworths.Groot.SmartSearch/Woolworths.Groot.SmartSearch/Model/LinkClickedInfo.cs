using MongoDB.Bson.Serialization.Attributes;

namespace Woolworths.Groot.SmartSearch.Model
{
    [BsonIgnoreExtraElements]
    public class LinkClickedInfo
    {
        [BsonElement("searchTerm")]
        public string? SearchTerm { get; set; }
        [BsonElement("link")]
        public string? Link { get; set; }
    }
}