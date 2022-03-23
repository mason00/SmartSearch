using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize]
        public IActionResult ValidateToken([FromHeader] string authorization)
        {
            return Ok();
        }
    }
}
