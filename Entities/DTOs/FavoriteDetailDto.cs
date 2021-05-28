using System.Collections.Generic;
using Castle.DynamicProxy.Generators.Emitters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DTOs
{
    public class FavoriteDetailDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<ProductDetailDto> ProductDetailDtos { get; set; }

    }
}