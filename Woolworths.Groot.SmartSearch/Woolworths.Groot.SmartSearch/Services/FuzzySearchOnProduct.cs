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

            var fuzzySearch = @"{
                '$search': {
                    'index': 'fuzzy brand', 
                    'text': {
                        'query': '" + text + @"', 
                        'path': ['Brand', 'GenericProductName', 'Description'], 
                        'fuzzy': {}
                    }, 
                    'highlight': {
                        'path': 'Brand'
                    }
                }
            }";

            var aggregatePipe = new EmptyPipelineDefinition<BsonDocument>()
                .AppendStage<BsonDocument, BsonDocument, Product>(fuzzySearch)
                .Limit(20)
            ;

            var result = await productCollection.AggregateAsync(aggregatePipe);
            var bsonProduct = await result.ToListAsync();
            return bsonProduct;
        }

        public async Task<List<Product>> FuzzySearchProduct(string text)
        {
            var productCollection = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName).GetCollection<Product>(MongoDbConstant.ProductCollection);
            var aggregate = productCollection.Aggregate().Match(x => x.Stockcode == 79).Limit(20);
            return await aggregate.ToListAsync();
        }
    }
}
