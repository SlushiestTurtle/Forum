using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class ForumIndex
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm}")]
        public DateTime Created { get; set; }
    }
}
