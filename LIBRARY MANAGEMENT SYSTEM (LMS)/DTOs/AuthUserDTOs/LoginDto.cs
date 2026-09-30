using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.AuthUserDTOs
{
    public class LoginDto
    {
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
    }
}
