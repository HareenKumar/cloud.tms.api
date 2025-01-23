using cloud.tms.domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace cloud.tms.domain.Masters.Location
{
    [Table("Locations")]
    public class LocationEntity : BaseEntity
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

    }
}
