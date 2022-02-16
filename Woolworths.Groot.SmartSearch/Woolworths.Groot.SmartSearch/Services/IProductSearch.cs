using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.Model;

namespace Woolworths.Groot.SmartSearch.Services
{
    public interface IProductSearch
    {
        IMongoCollection<Product> Product { get; }

        Task<List<Product>> Search(string term);
    }
}