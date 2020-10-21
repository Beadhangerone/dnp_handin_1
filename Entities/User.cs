using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace h1.Entities
{
    public class User : IdentityUser
    {
        override
        public string Id
        { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        override
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
