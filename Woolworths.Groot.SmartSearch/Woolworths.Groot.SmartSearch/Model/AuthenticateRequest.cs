using System.ComponentModel.DataAnnotations;

namespace Woolworths.Groot.SmartSearch.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string IdToken { get; set; }
    }
}
