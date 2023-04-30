using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Post
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        public string? Content { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedDate { get; set; }
        public ForumThread? Thread { get; set; }
        public User User { get; set; }
        public Post(long id, string title, string content, string description, DateTime createDate, DateTime updateDate, ForumThread thread, User user)
        {
            Id = id;
            Title = title;
            Content = content;
            Description = description;
            CreatedDate = createDate;
            UpdatedDate = updateDate;
            Thread = thread;
            User = user;
        }
    }
}
