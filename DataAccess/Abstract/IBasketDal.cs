using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IBasketDal:IEntityRepository<Basket>
    {
        Task<List<BasketDetailDto>> GetBasketDetails(Expression<Func<BasketDetailDto, bool>> filter = null);
    }
}