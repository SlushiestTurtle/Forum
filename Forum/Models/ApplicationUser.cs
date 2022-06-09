using Microsoft.AspNetCore.Identity;

namespace Forum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
