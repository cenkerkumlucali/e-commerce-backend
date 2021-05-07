using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserCommentService
    {
        IDataResult<List<UserComment>> GetAll();
        IDataResult<List<UserComment>> GetAllByUserId(int userId);
        IDataResult<List<UserComment>> GetAllByProductId(int productId);
        IResult Add(UserComment userComment);
        IResult Delete(UserComment userComment);
        IResult Update(UserComment userComment);

    }
}