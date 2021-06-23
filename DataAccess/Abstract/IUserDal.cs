using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<UserDetailDto> GetUserDetails(Expression<Func<UserDetailDto, bool>> filter = null);

        List<OperationClaim> GetClaims(User user);
    }
}