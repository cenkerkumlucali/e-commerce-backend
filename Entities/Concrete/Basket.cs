using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Basket:IEntity
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}