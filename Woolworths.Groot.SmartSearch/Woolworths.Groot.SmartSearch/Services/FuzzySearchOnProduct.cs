using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class FuzzySearchOnProduct : IFuzzySearchOnProduct
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public FuzzySearchOnProduct(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public async Task<List<Product>> FuzzySearchBsonProduct(string text)
        {
            var productCollection = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName).GetCollection<BsonDocument>(MongoDbConstant.ProductCollection);
                        var fuzzySearch = @"
                { '$search': {
            index: 'fuzzy brand', 
            'text': {
                'query': 'supee', 
                'path': 'Brand', 
                'fuzzy': {}
            }, 
            'highlight': {
                'path': 'Brand'
            }
        } }
            ";
                        var projection = @"
            {
                'Description': {
                    '$meta': 'searchHighlights'
                }, 
                'Brand': 1
            }";

            //            var fuzzySearch = new BsonArray
            //{
            //    new BsonDocument("$search",
            //    new BsonDocument
            //        {
            //            { "index", "fuzzy brand" },
            //            { "text",
            //    new BsonDocument
            //            {
            //                { "query", "super" },
            //                { "path", "Brand" }
            //            } }
            //        })
            //};
            //var fuzzySearch = new BsonDocument
            //{
            //    {
            //        "$search", new BsonDocument
            //        {
            //            {"index", "fuzzy brand"},
            //            {
            //                "text", new BsonDocument
            //                {
            //                    { "query", "supee"},
            //                    { "path", "Brand"},
            //                    { "fuzzy", new BsonDocument{ } }
            //                }
            //            },
            //            {
            //                "highlight", new BsonDocument
            //                {
            //                    { "path", "Brand" }
            //                }
            //            },
            //        }
            //    },
            //};
            //var match = new BsonDocument { { "$match", new BsonDocument { } } };
            //var limit20 = new BsonDocument
            //{
            //    {
            //        "$limit", 20
            //    }
            //};
            //var projectBrand = new BsonDocument
            //{
            //    {
            //        "$project", new BsonDocument { { "Brand", 1 } }
            //    }
            //};
            var p = Builders<Product>.Projection.Include(x => x.Brand).Include(x => x.Stockcode);
            var pMeta = Builders<BsonDocument>.Projection.Include("Brand").Include("Stockcode")
                .Meta("HighLights", "searchHighlights");

            var aggregatePipe = new EmptyPipelineDefinition<BsonDocument>()
                .AppendStage<BsonDocument, BsonDocument, BsonDocument>(fuzzySearch)
                .Limit(20)
                .Project(pMeta)
            //.Project(projection)
            //.Project(x => x.)
            ;
            //.AppendStage<BsonDocument, BsonDocument, BsonDocument>(limit20)
            //.AppendStage<BsonDocument, BsonDocument, BsonDocument>(projectBrand);

            //productCollection.Aggregate()
            //PipelineDefinition<Transport, Transport> pipeline = fuzzySearch;


            var result = await productCollection.AggregateAsync(aggregatePipe);
            var bsonProduct = await result.ToListAsync();
            //return bsonProduct;
            var fProduct = bsonProduct.First();
            var sResult = BsonSerializer.Deserialize<Product>(fProduct);
            return null;
        }

        public async Task<List<Product>> FuzzySearchProduct(string text)
        {
            var productCollection = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName).GetCollection<Product>(MongoDbConstant.ProductCollection);
            var aggregate = productCollection.Aggregate().Match(x => x.Stockcode == 79).Limit(20);
            return await aggregate.ToListAsync();
        }
    }
}
