using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.Model;

namespace Woolworths.Groot.SmartSearch.Services
{
    public interface IRentSearch
    {
        IMongoCollection<Rent> Rent { get; }
        long RentCount();
        Task<List<Rent>> SearchWithTerm(string term);
    }
}