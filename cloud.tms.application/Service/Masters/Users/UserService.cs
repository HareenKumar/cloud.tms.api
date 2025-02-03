
using AutoMapper;
using cloud.tms.application.DTO;
using cloud.tms.domain.Masters.User;
using cloud.tms.domain.Repository;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using System.Data;
using Dapper;
using Microsoft.CodeAnalysis.Scripting;


namespace cloud.tms.application.Service.Masters.Users
{
    public class UserService : IUserService
    {
        public readonly IMasterRepository<UserEntity> _masterRepository;
        public readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;
        public UserService(IMasterRepository<UserEntity> masterRepository, IMapper mapper, IDbConnection dbConnection)
        {
            _masterRepository = masterRepository;
            _mapper = mapper;
            _dbConnection = dbConnection;
        }
        public async Task<int> CreateUserAsync(UserDto user)
        {
            //Hash the password
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hash = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            var entity = _mapper.Map<UserEntity>(user);
            entity.PasswordSalt = salt;
            entity.PasswordHash = hash;
            return await _masterRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _masterRepository.DeleteAsync(id);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var entity = await _masterRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var entities = await _masterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(entities);
        }

        public async Task<bool> UpdateUserAsync(UserDto user, int id)
        {
            var entity = _mapper.Map<UserEntity>(user);
            return await _masterRepository.UpdateAsync(id, entity);
        }

        
        public async Task<bool> UserExistsAsync(string email)
        {
            string sql = "SELECT COUNT(*) FROM \"Users\" WHERE \"Email\" = @Email";
            int count = await _dbConnection.ExecuteScalarAsync<int>(sql, new { Email = email });
            return count > 0;
        }



    }
}
