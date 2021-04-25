using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class ProductsImage : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public ProductsImage()
        {
            Date=DateTime.Now;
        }
    }
}