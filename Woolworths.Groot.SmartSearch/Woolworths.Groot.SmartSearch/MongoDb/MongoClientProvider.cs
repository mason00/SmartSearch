using MongoDB.Driver;

namespace Woolworths.Groot.SmartSearch.MongoDb
{
    public class MongoClientProvider : IMongoClientProvider
    {
        private MongoClient client;

        public MongoClientProvider(IConfiguration config)
        {
            client = new MongoClient(config["MongoDb"]);
        }

        public IMongoClient GetClient()
        {
            return client;
        }
    }
}
