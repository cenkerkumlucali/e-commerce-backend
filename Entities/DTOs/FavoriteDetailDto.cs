using System.Collections.Generic;

namespace Entities.DTOs
{
    public class FavoriteDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public long BrandId { get; set; }
        public string UserFullName { get; set; }
        public string ProductName { get; set; }
        public List<string> Images { get; set; }
        public decimal Price { get; set; }
        public int DiscountRate { get; set; }
    }
}