using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductCommentService:IGenericCrudOperationService<ProductComment>
    {
        Task<IDataResult<List<ProductCommentDto>>> GetDetail();
        Task<IDataResult<List<ProductCommentDto>>> GetDetailByUserId(int userId);
        Task<IDataResult<List<ProductCommentDto>>> GetDetailByUserIdAndId(int userId,int id);

        Task<IDataResult<List<ProductCommentDto>>> GetDetailByProductId(int productId);
        Task<IDataResult<List<ProductComment>>> GetAllByUserId(int userId);
        Task<IDataResult<List<ProductComment>>> GetAllByProductId(int productId);
    }
}