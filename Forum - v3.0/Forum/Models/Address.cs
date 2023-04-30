using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
    }
}