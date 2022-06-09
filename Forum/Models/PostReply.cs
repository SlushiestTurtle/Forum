using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Forum.Models
{
    public class PostReply
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm}")]
        public DateTime Created { get; set; }
        [Required, NotNull]
        public ApplicationUser User { get; set; }
        [Required, NotNull]
        public Post Post { get; set; }
    }
}
