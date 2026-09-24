using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public int PublishedYear { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price    { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
