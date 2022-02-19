using Woolworths.Groot.SmartSearch.Model;

namespace Woolworths.Groot.SmartSearch.Services
{
    public interface IAutocompleteOnBrandService
    {
        Task<List<Brand>> Autocomplete(string term);
    }
}