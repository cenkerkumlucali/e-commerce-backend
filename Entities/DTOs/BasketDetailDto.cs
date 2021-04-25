using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class BasketDetailDto:IDto
    {
        public long BasketId { get; set; }
        public string ProductName { get; set; }
        public string UserFullName { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}