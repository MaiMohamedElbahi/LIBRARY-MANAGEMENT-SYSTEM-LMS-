using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
