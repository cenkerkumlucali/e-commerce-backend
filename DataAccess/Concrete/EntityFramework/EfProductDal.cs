using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from product in context.Products
                    join category in context.Categories
                        on product.CategoryId equals category.CategoryId
                    join brand in context.Brands
                        on product.BrandId equals brand.Id
                    select new ProductDetailDto
                    {
                        ProductId = product.Id,
                        BrandId = brand.Id,
                        CategoryId = category.CategoryId,
                        Images = 
                            (from i in context.ProductsImages where i.ProductId == product.Id select i.ImagePath).ToList(),
                        CategoryName = category.Name,
                        BrandName = brand.Name,
                        ProductName = product.Name,
                        Description = product.Description,
                        Code = product.Code,
                        DiscountRate = product.DiscountRate,
                        Price = product.Price,
                        CreateDate = product.CreateDate,
                        Active = product.Active,
                        
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}