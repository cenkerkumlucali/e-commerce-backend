using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class UserCommentImage:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}