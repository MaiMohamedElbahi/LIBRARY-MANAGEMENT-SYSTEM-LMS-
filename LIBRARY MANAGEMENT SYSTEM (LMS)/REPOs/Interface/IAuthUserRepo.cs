using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.AuthUserDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Interface
{
    public interface IAuthUserRepo : IGenericRepo<AuthUser>
    {
        string Register(RegisterDto dto);
        LoginResponseDto Login(LoginDto dto);
        AuthUser GetByName(string name);
    }
}
