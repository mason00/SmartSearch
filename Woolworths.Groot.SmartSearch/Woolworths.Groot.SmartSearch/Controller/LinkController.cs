using Microsoft.AspNetCore.Mvc;
using Woolworths.Groot.SmartSearch.Model;
using Woolworths.Groot.SmartSearch.Services;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService linkService;

        public LinkController(ILinkService linkService)
        {
            this.linkService = linkService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveLinkClickedInfo(LinkClickedInfo info)
        {
            await linkService.SaveLinkClickedInfo(info);
            return Ok();
        }
    }
}
