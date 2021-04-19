using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public long AddressId { get; set; }
        public int OrderStatusId { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}