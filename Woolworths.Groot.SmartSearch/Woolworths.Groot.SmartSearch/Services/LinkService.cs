using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class LinkService : ILinkService
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public LinkService(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public async Task SaveLinkClickedInfo(LinkClickedInfo info)
        {
            var linkClickCollection = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName)
                .GetCollection<LinkClickedInfo>(MongoDbConstant.LinkClickedCollection);

            await linkClickCollection.InsertOneAsync(info);
        }
    }
}
