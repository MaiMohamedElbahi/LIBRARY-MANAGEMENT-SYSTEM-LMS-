using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.MemberDTOs
{
    public class PartiallyUpdateMemberDTO
    {
        public int? MemberId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }


    }
}
