using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductCommentService
    {
        IDataResult<List<ProductComment>> GetAll();
        IDataResult<List<ProductComment>> GetAllByUserId(int userId);
        IDataResult<List<ProductComment>> GetAllByProductId(int productId);
        IResult Add(ProductComment productComment);
    }
}