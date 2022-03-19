using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Woolworths.Groot.SmartSearch.Model;

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
        public IActionResult ValidateToken([FromHeader] string authorization)
        {
            var token = authorization.Split(' ')[1];

            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            // Change this to your google client ID
            settings.Audience = new List<string>() { "535648816304-dqqvv9tnv9e38vdo0debrov4ps63jdgg.apps.googleusercontent.com" };

            GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(token, settings).Result;
            return Ok(payload.Email);
        }
    }
}
