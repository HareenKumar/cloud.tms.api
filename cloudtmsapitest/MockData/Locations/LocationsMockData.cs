using cloud.tms.application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudtmsapitest.MockData.Locations
{
    public class LocationsMockData
    {
        public static IEnumerable<LocationDto> GetLocations()
        {
            return new List<LocationDto>
            {
                new LocationDto {
                    Id = 1,
                    LocationName = "Lamresearch",
                    ContactName = "Neha",
                    AddressLine1 = "Light Street",
                    AddressLine2 = "Apt 16",
                    City = "Fremont",
                    State = "CA",
                    PostalCode = "94538",
                    Country = "USA",
                    Phone = "9949944650",
                    Email = "info@bhuvi.com",
                    CountryCode = "US",
                    Status = true,
                },
                new LocationDto {
                    Id= 2,
                    LocationName = "Velcro",
                    ContactName = "Hector",
                    AddressLine1 = "Parkway Street",
                    AddressLine2 = "Site 230",
                    City = "Manchester",
                    State = "NY",
                    PostalCode = "88862",
                    Country = "USA",
                    Phone = "9949944650",
                    Email = "info@bhuvi.com",
                    CountryCode = "US",
                    Status = true,
                },
                new LocationDto
                {
                    Id= 3,
                    LocationName = "Syntex Inc",
                    ContactName = "David",
                    AddressLine1 = "Fulton County",
                    AddressLine2 = "Site 100",
                    City = "Johns Creak",
                    State = "GA",
                    PostalCode = "30097",
                    Country = "USA",
                    Phone = "9949944650",
                    Email = "info@bhuvi.com",
                    CountryCode = "US",
                    Status = true,
                }
            };
        }

        public static IEnumerable<LocationDto> EmptyLocations()
        {
            return Enumerable.Empty<LocationDto>();
        }
    }
}
