using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Woolworths.Groot.SmartSearch.Hubs;
using Woolworths.Groot.SmartSearch.Services;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class SmartSearchController : ControllerBase
    {
        private readonly IProductSearch productSearch;
        private readonly ISaveSearchTermService saveSearchTermService;
        private readonly FullTextSearchStreamSource fullTextSearchStreamSource;

        public SmartSearchController(IProductSearch productSearch,
            ISaveSearchTermService saveSearchTermService,
            FullTextSearchStreamSource fullTextSearchStreamSource)
        {
            this.productSearch = productSearch;
            this.saveSearchTermService = saveSearchTermService;
            this.fullTextSearchStreamSource = fullTextSearchStreamSource;
            //this.searchHubInstance = searchHubInstance;
            //this.searchHub = searchHub;
            //this.hubContext = hubContext;
        }

        public FullTextSearchStreamSource FullTextSearchStreamSource { get; }

        [HttpGet("{term}")]
        public async Task<IActionResult> Search(string term)
        {
            //fullTextSearchStreamSource.bump.OnNext(term);

            fullTextSearchStreamSource.WriteMsg(term);

            //fullTextSearchStreamSource.WriteMsg(term);

            saveSearchTermService.SaveTerm(term);

            return Ok(await productSearch.Search(term));
        }
    }
}
