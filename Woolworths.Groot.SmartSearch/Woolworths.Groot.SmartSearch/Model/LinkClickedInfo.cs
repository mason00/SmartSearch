using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Woolworths.Groot.SmartSearch.Model
{
    [BsonIgnoreExtraElements]
    public class LinkClickedInfo
    {
        public ObjectId Id { get; set; }
        [BsonElement("searchTerm")]
        public string? SearchTerm { get; set; }
        [BsonElement("link")]
        public string? Link { get; set; }
        [BsonElement("termHash")]
        public string? TermHash { get; set; }
    }
}