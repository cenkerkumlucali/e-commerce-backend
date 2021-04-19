using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class OrderDetails:IEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int SalePrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}