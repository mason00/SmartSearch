using MongoDB.Bson;
using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class RentSearch : IRentSearch
    {
        private readonly IMongoClientProvider mongoClientProvider;
        private IMongoCollection<Rent> rent;

        public RentSearch(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public IMongoCollection<Rent> Rent
        {
            get
            {
                if (rent == null)
                {
                    rent = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName).GetCollection<Rent>(MongoDbConstant.RentCollection);
                }
                return rent;
            }
            private set { }
        }

        public long RentCount()
        {
            return Rent.CountDocuments(FilterDefinition<Rent>.Empty);
        }

        public async Task<List<Rent>> SearchWithTerm(string term)
        {
            var filter = Builders<Rent>.Filter.Text(term);
            //var projection = Builders<Rent>.Projection.Include(x => x.Name).Include(x => x.Description);
            return await Rent.Find(filter).Limit(50).ToListAsync();
        }
    }
}
