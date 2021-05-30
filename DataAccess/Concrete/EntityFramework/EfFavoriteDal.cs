using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
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
                             join product in context.Products on contextFavorite.ProductId equals product.Id
                             select new FavoriteDetailDto()
                             {
                                 UserId = user.Id,
                                 UserFullName = $"{user.FirstName} {user.LastName}",
                                 Price = product.Price,
                                 Images = (from i in context.ProductsImages where i.ProductId == contextFavorite.ProductId select i.ImagePath).ToList(),
                                 ProductName = product.Name,
                                 DiscountRate = product.DiscountRate,
                                 ProductId = product.Id

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}