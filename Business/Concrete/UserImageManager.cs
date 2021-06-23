using System.Collections.Generic;
using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        private IUserImageDal _userImageDal;

        public UserImageManager(IUserImageDal userImageDal)
        {
            _userImageDal = userImageDal;
        }
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(IFormFile file, UserImage userImage)
        {
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            userImage.ImagePath = imageResult.Message;
            _userImageDal.AddAsync(userImage);
            return new SuccessResult("Resim eklendi");
        }
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(UserImage userImage)
        {
            _userImageDal.DeleteAsync(userImage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(IFormFile file, UserImage userImage)
        {
            var imageResult = FileHelper.Update(file,userImage.ImagePath);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            userImage.ImagePath = imageResult.Message;
            _userImageDal.UpdateAsync(userImage);
            return new SuccessResult();
        }

        public IDataResult<UserImage> Get(int id)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll());
        }

        public IDataResult<List<UserImage>> GetImagesByTId(int id)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(c => c.Id == id));
        }
    }
}