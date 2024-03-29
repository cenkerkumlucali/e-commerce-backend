﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserCommentService:IGenericCrudOperationService<UserComment>
    {
        Task<IDataResult<List<UserComment>>> GetAllByUserId(int userId);

    }
}