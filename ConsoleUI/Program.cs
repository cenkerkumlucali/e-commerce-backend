
using DataAccess.Concrete.EntityFramework;

using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfProductDal efProductDal = new EfProductDal();
            Product product1 = new Product();
            product1.Name = "";
            product1.CategoryId=2;
            product1.BrandId =1;
            product1.CreateDate=DateTime.Now;
            product1.Code = "WTR01";
            product1.Name="Su";
            product1.Active = true;
            product1.Price=2;
            
            efProductDal.Add(product1);
            foreach (var product in efProductDal.GetAll())
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
