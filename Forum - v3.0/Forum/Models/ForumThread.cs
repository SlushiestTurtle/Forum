using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class ForumThread
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedDate { get; set; }
        public User? User { get; set; }
    }
}
