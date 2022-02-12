using MongoDB.Driver;

namespace Woolworths.Groot.SmartSearch.MongoDb
{
    public interface IMongoClientProvider
    {
        IMongoClient GetClient();
    }
}