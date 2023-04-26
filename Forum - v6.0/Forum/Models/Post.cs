using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Post
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public Thread? Thread { get; set; }
    }
}
