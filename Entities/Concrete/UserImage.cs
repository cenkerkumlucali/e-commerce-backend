using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class UserImage:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}