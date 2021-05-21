using Castle.DynamicProxy.Generators.Emitters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DTOs
{
    public class FavoriteDetailDto
    {
        public int  ProductId { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }

    }
}