using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Forum.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm}")]
        public DateTime Created { get; set; }
        [Required, NotNull]
        public ApplicationUser User { get; set; }
        [Required, NotNull]
        public ForumIndex Forum { get; set; }
    }
}
