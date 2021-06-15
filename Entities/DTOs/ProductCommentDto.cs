using System.Collections.Generic;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class ProductCommentDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UserFullName { get; set; }
        public List<string> ImagePath { get; set; }
        public string Comment { get; set; }
    }
}