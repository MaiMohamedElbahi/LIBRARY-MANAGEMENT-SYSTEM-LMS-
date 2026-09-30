namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.AuthUserDTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
