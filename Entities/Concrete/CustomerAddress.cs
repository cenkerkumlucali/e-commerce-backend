using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerAddress:IEntity
    {
      [Key]
      public int CustomerId { get; set; } 
      public int AddressId { get; set; }
    }
}