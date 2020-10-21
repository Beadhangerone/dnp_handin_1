using System;

namespace h1.Models
{
    public class User
    {
        public string Id
        { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}