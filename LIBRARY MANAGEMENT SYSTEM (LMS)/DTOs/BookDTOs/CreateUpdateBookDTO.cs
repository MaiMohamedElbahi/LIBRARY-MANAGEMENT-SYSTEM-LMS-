using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BookDTOs
{
    public class CreateUpdateBookDTO
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public int AvailableCopies { get; set; }
        public decimal Price    { get; set; }
    }
}
