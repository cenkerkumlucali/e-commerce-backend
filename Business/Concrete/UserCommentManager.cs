using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserCommentManager:IUserCommentService
    {
        private IUserCommentDal _userCommentDal;

        public UserCommentManager(IUserCommentDal userCommentDal)
        {
            _userCommentDal = userCommentDal;
        }
        [CacheRemoveAspect("IProductCommentManager")]
        [ValidationAspect(typeof(UserCommentValidator))]
        public async Task<IResult> Add(UserComment userComment)
        {
            await _userCommentDal.AddAsync(userComment);
            return new SuccessResult(Messages.AddedComment);
        }

        public async Task<IResult> Delete(UserComment userComment)
        {
            await _userCommentDal.DeleteAsync(userComment);
            return new SuccessResult(Messages.DeletedComment);
        }
        [CacheRemoveAspect("IProductCommentManager")]
        public async Task<IResult> Update(UserComment userComment)
        {
            await _userCommentDal.UpdateAsync(userComment);
            return new SuccessResult(Messages.UpdatedComment);
        }
        [CacheAspect]
        public async Task<IDataResult<List<UserComment>>> GetAll()
        {
            return new SuccessDataResult<List<UserComment>>(await _userCommentDal.GetAllAsync());
        }
        [CacheAspect]
        public async Task<IDataResult<List<UserComment>>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<UserComment>>(await _userCommentDal.GetAllAsync(c => c.UserId == userId));
        }

    }
}