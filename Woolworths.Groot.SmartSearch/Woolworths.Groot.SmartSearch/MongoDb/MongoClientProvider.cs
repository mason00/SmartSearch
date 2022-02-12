using MongoDB.Driver;

namespace Woolworths.Groot.SmartSearch.MongoDb
{
    public class MongoClientProvider
    {
        private MongoClient client;

        public MongoClientProvider(IConfiguration config)
        {
            client = new MongoClient(config["MongoDb"]);
        }
    }
}
