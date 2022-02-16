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
            var filter = Builders<Product>.Filter.Text(term);
            return await Product.Find(filter).Limit(50).ToListAsync();
        }
    }
}
