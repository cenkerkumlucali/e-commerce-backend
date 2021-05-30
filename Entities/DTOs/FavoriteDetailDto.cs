using System.Collections.Generic;
using Castle.DynamicProxy.Generators.Emitters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DTOs
{
    public class FavoriteDetailDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string UserFullName { get; set; }
        public string ProductName { get; set; }
        public List<string> Images { get; set; }
        public decimal Price { get; set; }
        public int DiscountRate { get; set; }
    }
}