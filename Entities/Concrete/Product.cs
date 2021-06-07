using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int DiscountRate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}