using Microsoft.AspNetCore.Mvc;

namespace Woolworths.Groot.SmartSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Check()
        {
            return Ok("live");
        }
    }
}
