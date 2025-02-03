
using cloud.tms.application.DTO;
using System.Globalization;

namespace cloud.tms.application.Service.Masters.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(UserDto user);
        Task<bool> UpdateUserAsync(UserDto user, int id);
        Task<bool> DeleteUserAsync(int id);

        Task<bool> UserExistsAsync(string email);
        //Task<bool> AuthenticateUserAsync(LoginDto loginDto);

    }
}
