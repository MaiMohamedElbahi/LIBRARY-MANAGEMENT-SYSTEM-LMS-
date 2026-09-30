using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class AuthUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
