using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerAddressDto:IDto
    {
        public int CustomerId { get; set; }
        public long AddressId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}