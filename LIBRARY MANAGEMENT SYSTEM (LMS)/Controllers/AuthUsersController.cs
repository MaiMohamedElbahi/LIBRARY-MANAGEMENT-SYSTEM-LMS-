using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.AuthUserDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUsersController : ControllerBase
    {
        private readonly IAuthUserRepo _authUserRepo;

        public AuthUsersController(IAuthUserRepo authUserRepo)
        {
            _authUserRepo = authUserRepo;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var res = _authUserRepo.Login(dto);
            if(res == null)
            {
                return BadRequest("Wrong Username or Password");
            }
            return Ok(res);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var res = _authUserRepo.Register(dto);
            if(res == null)
            {
                return BadRequest("Username already exists");
            }
            return Ok(res);
        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            
            return Ok(_authUserRepo.GetByName(name));
        }
    }
}
