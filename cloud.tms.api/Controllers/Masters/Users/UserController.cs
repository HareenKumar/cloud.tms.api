using cloud.tms.application.DTO;
using cloud.tms.application.Service.Masters.Users;
using cloud.tms.core.Core.Common.Helpers;
using cloud.tms.domain.Masters.User;
using cloud.tms.domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cloud.tms.api.Controllers.Masters.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetUsersAsync();
            if (result == null) { return NoContent(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            //check if the user exists
            if (await _userService.UserExistsAsync(userDto.Email))
            {
                return BadRequest("User already exists");
            }

            if (string.IsNullOrEmpty(userDto.Email))
            {
                return BadRequest(new { message = "Invalid JSON Data: Email not found." });
            }

            // Hash password before storing it
            //PasswordHelper.CreatePassword(userDto.Password, out string passwordHash, out string passwordSalt);
            //userDto.passwordHash = passwordHash;
            //userDto.passwordSalt = passwordSalt;
            var id = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserDto userDto, int id)
        {
            var result = await _userService.UpdateUserAsync(userDto, id);
            if (!result) { return NotFound(); }
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result) { return NotFound(); }
            return Ok(result);
        }
    }
}
