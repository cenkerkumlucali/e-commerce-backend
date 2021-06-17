using System.Collections.Generic;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class UserDetailDto:IDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public UserImage Image { get; set; }
    }
}