using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IOrderDetailsDal:IEntityRepository<OrderDetails>
    {
        List<OrderDetailsDto> GetProductDetails(Expression<Func<OrderDetailsDto, bool>> filter = null);

    }
}