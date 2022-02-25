using MongoDB.Bson;
using Woolworths.Groot.SmartSearch.Model;

namespace Woolworths.Groot.SmartSearch.Services
{
    public interface IFuzzySearchOnProduct
    {
        Task<List<Product>> FuzzySearchProduct(string text);
        Task<List<Product>> FuzzySearchBsonProduct(string text);
        Task<List<Product>> FuzzySearchWithBrand(string brand, string text);
    }
}