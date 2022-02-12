using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Woolworths.Groot.SmartSearch.MongoDb;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartSearchController : ControllerBase
    {
        private readonly MongoClientProvider dbProvider;

        public SmartSearchController(MongoClientProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var client = new MongoClient("mongodb://admin:password@localhost:27017");
            var db = client.GetDatabase("pluralsight").DatabaseNamespace;
            return Ok(db);
        }
    }
}
