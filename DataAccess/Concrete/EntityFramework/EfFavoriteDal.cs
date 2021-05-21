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
    public class EfFavoriteDal:EfEntityRepositoryBase<Favorite,NorthwindContext>,IFavoriteDal
    {
        public List<FavoriteDetailDto> GetAllDetails(Expression<Func<FavoriteDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from contextFavorite in context.Favorites
                    join product in context.Products on contextFavorite.ProductId equals product.Id
                    join user in context.Users on contextFavorite.UserId equals user.Id
                    select new FavoriteDetailDto()
                    {
                        ProductName = product.Name,
                        ProductId = product.Id,
                        UserFullName = $"{user.FirstName} {user.LastName}",
                        UserId = user.Id

                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}