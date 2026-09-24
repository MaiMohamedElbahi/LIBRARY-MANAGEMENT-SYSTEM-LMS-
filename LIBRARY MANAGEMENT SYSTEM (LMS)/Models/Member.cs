using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }


        public List<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    }
}
