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
        private readonly IMongoClientProvider dbProvider;
        private readonly IRentSearch rentSearch;

        public SmartSearchController(IMongoClientProvider dbProvider, IRentSearch rentSearch)
        {
            this.dbProvider = dbProvider;
            this.rentSearch = rentSearch;
        }

        [HttpGet("{term}")]
        public async Task<IActionResult> Search(string term)
        {
            return Ok(await rentSearch.SearchWithTerm(term));
        }
    }
}
