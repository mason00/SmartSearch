using System.Text;
using Woolworths.Groot.SmartSearch.Constant;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class SaveSearchTermService : ISaveSearchTermService
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public SaveSearchTermService(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public async Task SaveTerm(string term)
        {
            var termColl = mongoClientProvider.GetClient().GetDatabase(MongoDbConstant.DbName)
                .GetCollection<Term>(MongoDbConstant.TermCollection);

            var termHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(term));
            await termColl.InsertOneAsync(new Term { SearchTerm = term, TermHash = termHash });
        }
    }
}
