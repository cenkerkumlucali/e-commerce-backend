using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Country:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}