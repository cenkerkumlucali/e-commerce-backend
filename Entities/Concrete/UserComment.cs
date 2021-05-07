using System;
using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class UserComment:CommentBase,IEntity
    {
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}