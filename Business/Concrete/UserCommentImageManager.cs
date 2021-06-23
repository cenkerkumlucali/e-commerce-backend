using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserCommentImageManager:IUserCommentImageService
    {
        private IUserCommentImageDal _userCommentImageDal;

        public UserCommentImageManager(IUserCommentImageDal userCommentImageDal)
        {
            _userCommentImageDal = userCommentImageDal;
        }
        
        [CacheRemoveAspect("IProductService.Get")]
        public IResult AddAsync(List<IFormFile> file, UserCommentImage userCommentImage)
        {
            var error = "";
            List<UserCommentImage> images = new List<UserCommentImage>();
            var imageCount = _userCommentImageDal.GetAll(c => c.CommentId== userCommentImage.CommentId).Count;
            if (imageCount >= 2)
            {
                return new ErrorResult("One comment must have 5 or less images");
            }

            for (int i = 0; i < file.Count; i++)
            {
                var newImage = new UserCommentImage() { CommentId = userCommentImage.CommentId,UserId = userCommentImage.UserId,ProductId = userCommentImage.ProductId};
                var imageResult = FileHelper.Upload(file[i]);

                if (!imageResult.Success)
                {
                    error = imageResult.Message;
                    break;
                }
                else
                {
                    newImage.ImagePath = imageResult.Message;

                    images.Add(newImage);
                }
            }

            _userCommentImageDal.MultiAddAsync(images.ToArray());
            return new SuccessResult("Comment image added");
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult DeleteById(int id)
        {
            var images = _userCommentImageDal.Get(c => c.Id == id);
            _userCommentImageDal.DeleteAsync(images);
            return new SuccessResult();
        }
        public IResult Add(IFormFile file, UserCommentImage entity)
        {
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(UserCommentImage userCommentImage)
        {
            _userCommentImageDal.DeleteAsync(userCommentImage);
            return new SuccessResult();
        }
        [SecuredOperation("user")]
        [ValidationAspect(typeof(ProductImagesValidator))]
        public IResult Update(IFormFile file, UserCommentImage userCommentImage)
        {
            _userCommentImageDal.UpdateAsync(userCommentImage);
            return new SuccessResult();
        }

        public IDataResult<UserCommentImage> Get(int id)
        {
            return new SuccessDataResult<UserCommentImage>(_userCommentImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<UserCommentImage>> GetAll()
        {
            return new SuccessDataResult<List<UserCommentImage>>(_userCommentImageDal.GetAll());
        }

        public IDataResult<List<UserCommentImage>> GetImagesByTId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}