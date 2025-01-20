using AutoMapper;
using cloud.tms.application.Common;
using cloud.tms.application.Mappings;
using cloud.tms.domain.Masters.Location;

namespace cloud.tms.application.DTO
{
    public class LocationDto: BaseDto, IMapFrom<LocationEntity>
    {
        public string LocationName { get; set; }
        public string ContactName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationDto, LocationEntity>().ReverseMap();
        }
    }
}
