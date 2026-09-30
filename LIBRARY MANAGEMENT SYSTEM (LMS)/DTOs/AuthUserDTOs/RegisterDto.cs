using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.AuthUserDTOs
{
    public class RegisterDto
    {
        public string Role { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
    }
}
