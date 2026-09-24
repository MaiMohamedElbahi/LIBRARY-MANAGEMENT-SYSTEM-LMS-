using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models
{
    public class BorrowRecord
    {
        [Key]
        public int BorrowRecordId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId;
        public Book Book { get; set; }

    }
}
