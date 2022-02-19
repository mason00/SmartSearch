using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class AutocompleteOnBrandService : IAutocompleteOnBrandService
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public AutocompleteOnBrandService(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public async Task<List<Brand>> Autocomplete(string term)
        {
            var brands = new List<Brand>();

            var brandCollection = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName)
                .GetCollection<BsonDocument>(MongoDbConstant.BrandCollection);

            var autocomplete = @"{
                $search: {
                  index: 'default',
                  autocomplete: {
                    query: '" + term + @"',
                    path: 'BrandName',
                    fuzzy: { maxEdits: 1, prefixLength: 0 }
                  }
                }
            }";

            var aggregatePipe = new EmptyPipelineDefinition<BsonDocument>()
                .AppendStage<BsonDocument, BsonDocument, BsonDocument>(autocomplete)
                .Limit(20)
            ;

            var result = await brandCollection.AggregateAsync(aggregatePipe);
            var bsonBrands = await result.ToListAsync();

            bsonBrands.ForEach(b => brands.Add(BsonSerializer.Deserialize<Brand>(b)));
            return brands;
        }
    }
}
