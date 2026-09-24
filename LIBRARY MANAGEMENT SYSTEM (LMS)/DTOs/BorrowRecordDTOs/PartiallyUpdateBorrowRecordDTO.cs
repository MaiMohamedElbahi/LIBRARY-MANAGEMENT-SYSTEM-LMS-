using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOs
{
    public class PartiallyUpdateBorrowRecordDTO
    {
        public int? BorrowRecordId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}
