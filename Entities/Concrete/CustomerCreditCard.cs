using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerCreditCard:IEntity
    {
        [Key]
        public int CardId { get; set; }
        public int CustomerId { get; set; }
       
    }
}