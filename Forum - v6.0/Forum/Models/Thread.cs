using Forum.Enum;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Thread
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public Catagory catagory { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
