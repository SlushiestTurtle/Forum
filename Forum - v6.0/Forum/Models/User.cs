using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required, MinLength(8)]
        public string? Password { get; set; }

    }
}
