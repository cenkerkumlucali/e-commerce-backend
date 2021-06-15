using System.Collections.Generic;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserDetailDto:IDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public List<string> Images { get; set; }
    }
}