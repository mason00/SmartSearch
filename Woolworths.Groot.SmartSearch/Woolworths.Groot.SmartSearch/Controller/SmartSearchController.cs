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

        public SmartSearchController(IProductSearch productSearch)
        {
            //this.dbProvider = dbProvider;
            //this.rentSearch = rentSearch;
            this.productSearch = productSearch;
        }

        [HttpGet("{term}")]
        public async Task<IActionResult> Search(string term)
        {
            return Ok(await productSearch.Search(term));
        }
    }
}
