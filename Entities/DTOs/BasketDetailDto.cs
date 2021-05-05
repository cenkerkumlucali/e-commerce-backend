using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.DTOs
{
    public class BasketDetailDto:IDto
    {
        public long BasketId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }

        public string BrandName { get; set; }
        public string UserFullName { get; set; }
        public decimal Price { get; set; }
        public List<string> Images { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}