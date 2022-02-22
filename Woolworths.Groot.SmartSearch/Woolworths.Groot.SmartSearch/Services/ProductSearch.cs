using MongoDB.Bson;
using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class ProductSearch : IProductSearch
    {
        private readonly IMongoClientProvider mongoClientProvider;
        private IMongoCollection<Product> product;

        public ProductSearch(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public IMongoCollection<Product> Product
        {
            get
            {
                if (product == null)
                {
                    product = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName).GetCollection<Product>(MongoDbConstant.ProductCollection);
                }
                return product;
            }
            private set { }
        }

        public async Task<List<Product>> Search(string term)
        {
            var productBson = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName).GetCollection<BsonDocument>(MongoDbConstant.ProductCollection);

            var proj = @"{
                '_id': 1, 
                'Stockcode': 1, 
                'Description': 1, 
                'Brand': 1, 
                'GenericProductName': 1, 
                'textScore': {
                    '$meta': 'textScore'
                }
            }";

            var pipeDef = new EmptyPipelineDefinition<BsonDocument>()
                .Match(Builders<BsonDocument>.Filter.Text(term))
                .Project<BsonDocument, BsonDocument, Product>(proj)
                .Sort(Builders<Product>.Sort.Descending(x => x.FullTextScore))
                .Limit(20);

            var bsonResult = await productBson.AggregateAsync(pipeDef);
            var productList = await bsonResult.ToListAsync();

            return productList;
        }
    }
}
