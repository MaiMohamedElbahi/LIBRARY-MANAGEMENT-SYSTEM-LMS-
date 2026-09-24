using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOs
{
    public class CreateUpdateBorrowRecordDTO
    {
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}
