using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloud.tms.domain.Masters.Location
{
    public class LocationEntity
    {
        public int Id { get; set; }
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
