using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }

        public List<string> Images { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        
    }
}