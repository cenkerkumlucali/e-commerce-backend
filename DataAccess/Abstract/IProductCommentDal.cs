using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductCommentDal:IEntityRepository<ProductComment>
    {
        List<ProductCommentDto> GetProductCommentDetail(Expression<Func<ProductCommentDto,bool>>filter = null);
    }
}