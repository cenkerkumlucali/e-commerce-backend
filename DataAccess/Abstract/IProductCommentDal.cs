using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductCommentDal:IEntityRepository<ProductComment>
    {
        Task<List<ProductCommentDto>> GetProductCommentDetail(Expression<Func<ProductCommentDto,bool>>filter = null);
    }
}