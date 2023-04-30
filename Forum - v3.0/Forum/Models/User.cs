using Microsoft.AspNetCore.Identity;

namespace Forum.Models
{
    public class User : IdentityUser
    {
        public string? Username { get; set; }
        public DateTime Birthday { get; set; }
        public Address? Address { get; set; }
    }
}
