using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IFavoriteDal:IEntityRepository<Favorite>
    {
        List<FavoriteDetailDto> GetAllDetails(Expression<Func<FavoriteDetailDto, bool>> filter = null);
    }
}