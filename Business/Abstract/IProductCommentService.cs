using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductCommentService
    {
        IDataResult<List<ProductComment>> GetAll();
        IDataResult<List<ProductCommentDto>> GetDetail();
        IDataResult<List<ProductCommentDto>> GetDetailByUserId(int userId);
        IDataResult<List<ProductCommentDto>> GetDetailByProductId(int productId);
        IDataResult<List<ProductComment>> GetAllByUserId(int userId);
        IDataResult<List<ProductComment>> GetAllByProductId(int productId);
        IResult Add(ProductComment productComment);
    }
}