using System.Collections.Generic;
using Core.Entities;

namespace Entities.DTOs
{
    public class BrandDetailDto:IDto
    {
        public long BrandId { get; set; }
        public string BrandName { get; set; }
        public List<string> Images { get; set; }
    }
}