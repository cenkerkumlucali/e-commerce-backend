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
    public class EfFavoriteDal : EfEntityRepositoryBase<Favorite, NorthwindContext>, IFavoriteDal
    {
        public List<FavoriteDetailDto> GetAllDetails(Expression<Func<FavoriteDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from contextFavorite in context.Favorites
                    join user in context.Users on contextFavorite.UserId equals user.Id
                    select new FavoriteDetailDto()
                    {

                        UserFullName = $"{user.FirstName} {user.LastName}",
                        UserId = user.Id,
                        ProductDetailDtos = (from product in context.Products
                                 where product.Id == contextFavorite.ProductId
                                 join category in context.Categories
                                     on product.CategoryId equals category.CategoryId
                                 join brand in context.Brands
                                     on product.BrandId equals brand.Id
                                 select new ProductDetailDto
                                 {
                                     ProductId = product.Id,
                                     BrandId = brand.Id,
                                     CategoryId = category.CategoryId,
                                     CategoryName = category.Name,
                                     BrandName = brand.Name,
                                     ProductName = product.Name,
                                     Description = product.Description,
                                     Code = product.Code,
                                     Rating = product.Rating,
                                     DiscountRate = product.DiscountRate,
                                     Price = product.Price,
                                     CreateDate = product.CreateDate,
                                     Active = product.Active,
                                     Images = (from i in context.ProductsImages where i.ProductId == product.Id select i.ImagePath).ToList(),

                                 }).ToList(),

                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}