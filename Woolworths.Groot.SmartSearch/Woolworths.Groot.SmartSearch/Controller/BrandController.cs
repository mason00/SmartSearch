using Microsoft.AspNetCore.Mvc;
using Woolworths.Groot.SmartSearch.Services;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IAutocompleteOnBrandService autocompleteOnBrandService;
        private readonly ISaveSearchTermService saveSearchTermService;

        public BrandController(IAutocompleteOnBrandService autocompleteOnBrandService, ISaveSearchTermService saveSearchTermService)
        {
            this.autocompleteOnBrandService = autocompleteOnBrandService;
            this.saveSearchTermService = saveSearchTermService;
        }

        [HttpGet("autocomplete/{term}")]
        public async Task<IActionResult> Autocomplete(string term)
        {
            saveSearchTermService.SaveTerm(term);

            return Ok(await autocompleteOnBrandService.Autocomplete(term));
        }
    }
}
