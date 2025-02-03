using AutoMapper;
using cloud.tms.application.Common;
using cloud.tms.application.Mappings;
using cloud.tms.domain.Masters.User;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace cloud.tms.application.DTO
{
    public class UserDto: BaseDto, IMapFrom<UserEntity>
    {
        public string CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Plaintext for registration
        public JsonDocument JsonData { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserDto, UserEntity>().ReverseMap();
        }
    }
}
