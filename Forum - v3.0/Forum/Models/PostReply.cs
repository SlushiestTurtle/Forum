using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class PostReply
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        public string? Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdateDate { get; set; }
        public Post? Post { get; set; }
        public User? User { get; set; }
        public PostReply(long id, string? title, string? content, DateTime? createdDate, DateTime? updateDate)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedDate = createdDate;
            UpdateDate = updateDate;
        }
    }
}
