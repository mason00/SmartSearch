using Microsoft.AspNetCore.Mvc;
using Woolworths.Groot.SmartSearch.Services;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartSearchController : ControllerBase
    {
        private readonly IProductSearch productSearch;
        private readonly ISaveSearchTermService saveSearchTermService;

        public SmartSearchController(IProductSearch productSearch, ISaveSearchTermService saveSearchTermService)
        {
            this.productSearch = productSearch;
            this.saveSearchTermService = saveSearchTermService;
        }

        [HttpGet("{term}")]
        public async Task<IActionResult> Search(string term)
        {
            saveSearchTermService.SaveTerm(term);

            return Ok(await productSearch.Search(term));
        }
    }
}
