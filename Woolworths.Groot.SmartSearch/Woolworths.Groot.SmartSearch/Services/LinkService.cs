using MongoDB.Driver;
using System.Text;
using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class LinkService : ILinkService
    {
        private readonly IMongoClientProvider mongoClientProvider;
        private readonly IMongoCollection<LinkClickedInfo> linkCollection;

        public LinkService(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
            linkCollection = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName)
                .GetCollection<LinkClickedInfo>(MongoDbConstant.LinkClickedCollection);
        }

        public async Task SaveLinkClickedInfo(LinkClickedInfo info)
        {
            info.TermHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(info.SearchTerm));

            await linkCollection.InsertOneAsync(info);
        }

        public async Task UpdateTermHash()
        {
            var all = linkCollection.Find(x => x.TermHash == null).ToList();

            foreach (var link in all)
            {
                var filter = Builders<LinkClickedInfo>.Filter.Eq(x => x.Id, link.Id);
                var updater = Builders<LinkClickedInfo>.Update.Set(x => x.TermHash,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(link.SearchTerm ?? string.Empty)));
                await linkCollection.UpdateOneAsync(filter, updater);
            }
        }
    }
}
