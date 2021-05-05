using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}   