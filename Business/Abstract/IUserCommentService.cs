using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserCommentService:IGenericCrudOperationService<UserComment>
    {
        IDataResult<List<UserComment>> GetAllByUserId(int userId);

    }
}