using Microsoft.AspNetCore.Identity;

namespace h1.Models
{
    public class User : IdentityUser
    {
        override
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SecurityLevel { get; set; }
    }
}