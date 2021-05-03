using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class BrandImagesManager:IBrandImagesService
    {
        private IBrandImagesDal _brandImagesDal;

        public BrandImagesManager(IBrandImagesDal brandImagesDal)
        {
            _brandImagesDal = brandImagesDal;
        }

        public IResult Add(IFormFile file, BrandImages brandImages)
        {
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            brandImages.ImagePath = imageResult.Message;
            _brandImagesDal.Add(brandImages);
            return new SuccessResult("Brand image added");
        }

        public IResult Delete(BrandImages brandImages)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(IFormFile file, BrandImages brandImages)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<BrandImages> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<BrandImages>> GetAll()
        {
            return new SuccessDataResult<List<BrandImages>>(_brandImagesDal.GetAll());
        }

        public IDataResult<List<BrandImages>> GetImagesByBrandId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}