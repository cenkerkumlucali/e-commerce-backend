using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
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
        [SecuredOperation("admin,product.add")]
        [CacheRemoveAspect("IBrandImagesService.Get")]
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
            var image = _brandImagesDal.Get(c => c.Id == brandImages.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _brandImagesDal.Delete(brandImages);
            return new SuccessResult("Image was deleted successfully");
        }
        [CacheRemoveAspect("IBrandImagesService.Get")]
        public IResult Update(IFormFile file, BrandImages brandImages)
        {
            var isImage = _brandImagesDal.Get(c => c.Id == brandImages.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            brandImages.ImagePath = updatedFile.Message;
            _brandImagesDal.Update(brandImages);
            return new SuccessResult("Car image updated");
        }
        [CacheAspect]
        public IDataResult<BrandImages> Get(int id)
        {
            return new SuccessDataResult<BrandImages>(_brandImagesDal.Get(p => p.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<BrandImages>> GetAll()
        {
            return new SuccessDataResult<List<BrandImages>>(_brandImagesDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<BrandImages>> GetImagesByBrandId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<BrandImages>>(result.Message);
            }

            return new SuccessDataResult<List<BrandImages>>(CheckIfCarImageNull(id).Data);
        }
        private IResult CheckImageLimitExceeded(int brandId)
        {
            var carImagecount = _brandImagesDal.GetAll(p => p.BrandId == brandId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<List<BrandImages>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _brandImagesDal.GetAll(c => c.BrandId == id).Any();
                if (!result)
                {
                    List<BrandImages> brandImage = new List<BrandImages>();
                    brandImage.Add(new BrandImages { BrandId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<BrandImages>>(brandImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<BrandImages>>(exception.Message);
            }

            return new SuccessDataResult<List<BrandImages>>(_brandImagesDal.GetAll(p => p.BrandId == id).ToList());
        }
        private IResult CarImageDelete(BrandImages carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}