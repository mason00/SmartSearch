using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Woolworths.Groot.SmartSearch.Services;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductSearchController : ControllerBase
    {
        private readonly IFuzzySearchOnProduct fuzzySearchOnProduct;
        private readonly ISaveSearchTermService saveSearchTermService;

        public ProductSearchController(IFuzzySearchOnProduct fuzzySearchOnProduct, ISaveSearchTermService saveSearchTermService)
        {
            this.fuzzySearchOnProduct = fuzzySearchOnProduct;
            this.saveSearchTermService = saveSearchTermService;
        }

        [HttpGet("{text}")]
        public async Task<IActionResult> FuzzySearch(string text)
        {
            saveSearchTermService.SaveTerm(text);

            return Ok(await fuzzySearchOnProduct.FuzzySearchBsonProduct(text));
        }

        [HttpGet]
        public async Task<IActionResult> FuzzySearch([FromQuery] string brand, [FromQuery] string text)
        {
            if (brand == null || text == null) return BadRequest();

            var queryString = HttpContext.Request.QueryString.Value;
            saveSearchTermService.SaveTerm(queryString);

            return Ok(await fuzzySearchOnProduct.FuzzySearchWithBrand(brand, text));
        }
    }
}
