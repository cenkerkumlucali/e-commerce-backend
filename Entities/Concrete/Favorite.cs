using System;
using System.Collections.Generic;
using Core.Entities;
using Entities.DTOs;

namespace Entities.Concrete
{
    public class Favorite:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public long BrandId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
       
    }
}