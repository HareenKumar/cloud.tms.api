using cloud.tms.application.DTO;
using cloud.tms.application.Service.Auth;
using Microsoft.AspNetCore.Mvc;

namespace cloud.tms.api.Controllers.Auth
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest();
            }

            var token = await _authService.AuthenticateAsync(loginDto);
            if (token == null) 
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }
            return Ok(new { token });
        }
    }
}
