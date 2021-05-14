using System.Collections.Generic;
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
        public IResult Add(UserComment userComment)
        {
            _userCommentDal.Add(userComment);
            return new SuccessResult(Messages.AddedComment);
        }

        public IResult Delete(UserComment userComment)
        {
            _userCommentDal.Delete(userComment);
            return new SuccessResult(Messages.DeletedComment);
        }
        [CacheRemoveAspect("IProductCommentManager")]
        public IResult Update(UserComment userComment)
        {
            _userCommentDal.Update(userComment);
            return new SuccessResult(Messages.UpdatedComment);
        }
        [CacheAspect]
        public IDataResult<List<UserComment>> GetAll()
        {
            return new SuccessDataResult<List<UserComment>>(_userCommentDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<UserComment>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<UserComment>>(_userCommentDal.GetAll(c => c.UserId == userId));
        }
        [CacheAspect]
        public IDataResult<List<UserComment>> GetAllByProductId(int productId)
        {
            return new SuccessDataResult<List<UserComment>>(_userCommentDal.GetAll(c => c.ProductId == productId));
        }
       
    }
}