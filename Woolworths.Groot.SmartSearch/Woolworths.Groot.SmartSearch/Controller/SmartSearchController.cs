using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.MongoDb;
using Woolworths.Groot.SmartSearch.Services;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartSearchController : ControllerBase
    {
        //private readonly IMongoClientProvider dbProvider;
        //private readonly IRentSearch rentSearch;
        private readonly IProductSearch productSearch;
        private readonly IFuzzySearchOnProduct fuzzySearchOnProduct;

        public SmartSearchController(IProductSearch productSearch, IFuzzySearchOnProduct fuzzySearchOnProduct)
        {
            //this.dbProvider = dbProvider;
            //this.rentSearch = rentSearch;
            this.productSearch = productSearch;
            this.fuzzySearchOnProduct = fuzzySearchOnProduct;
        }

        [HttpGet("{term}")]
        public async Task<IActionResult> Search(string term)
        {
            return Ok(await productSearch.Search(term));
        }

        [HttpGet("fuzzy/{text}")]
        public async Task<IActionResult> Fuzzy(string text)
        {
            //return Ok(await fuzzySearchOnProduct.FuzzySearchProduct(text));
            return Ok(await fuzzySearchOnProduct.FuzzySearchBsonProduct(text));
        }
    }
}
