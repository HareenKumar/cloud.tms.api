using cloud.tms.application.DTO;

namespace cloud.tms.application.Service.Auth
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(LoginDto loginDto);
    }
}
