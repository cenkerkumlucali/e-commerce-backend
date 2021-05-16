using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductCommentService:IGenericCrudOperationService<ProductComment>
    {
        IDataResult<List<ProductCommentDto>> GetDetail();
        IDataResult<List<ProductCommentDto>> GetDetailByUserId(int userId);
        IDataResult<List<ProductCommentDto>> GetDetailByProductId(int productId);
        IDataResult<List<ProductComment>> GetAllByUserId(int userId);
        IDataResult<List<ProductComment>> GetAllByProductId(int productId);
    }
}