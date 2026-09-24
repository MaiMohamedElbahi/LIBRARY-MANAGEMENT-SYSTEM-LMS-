using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs
{
    public class PartiallyUpdateCategoryDTO
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
    }
}
