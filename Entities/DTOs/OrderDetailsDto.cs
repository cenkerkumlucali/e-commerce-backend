using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class OrderDetailsDto
    {
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public string OrderStatus { get; set; }
        public List<string> Images { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}