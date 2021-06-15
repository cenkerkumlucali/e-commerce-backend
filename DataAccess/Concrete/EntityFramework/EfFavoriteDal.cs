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
                var result = from favorite in context.Favorites
                             join user in context.Users on favorite.UserId equals user.Id
                             join product in context.Products on favorite.ProductId equals product.Id
                             join brand in context.Brands on favorite.BrandId equals brand.Id
                             select new FavoriteDetailDto()
                             {
                                 Id=favorite.Id,
                                 UserId = user.Id,
                                 UserFullName = $"{user.FirstName} {user.LastName}",
                                 Price = product.Price,
                                 Images = (from i in context.ProductsImages where i.ProductId == favorite.ProductId select i.ImagePath).ToList(),
                                 ProductName = product.Name,
                                 DiscountRate = product.DiscountRate,
                                 ProductId = product.Id,
                                 BrandId = brand.Id
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}