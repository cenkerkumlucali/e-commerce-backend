using Core.Entities;

namespace Entities.DTOs
{
    public class ProductCommentDto:IDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UserFullName { get; set; }
        public string Comment { get; set; }
    }
}