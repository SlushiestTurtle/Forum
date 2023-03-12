using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Forum.Models
{
    public class ContactUs
    {
        [Key]
        public long Id { get; set; }
        [Required, NotNull]
        public string? From { get; set; }
        [Required, NotNull]
        public string? Subject { get; set; }
        [Required, NotNull]
        public string? Message { get; set; }
    }
}
