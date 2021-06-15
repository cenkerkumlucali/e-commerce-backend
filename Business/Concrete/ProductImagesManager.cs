using System;
using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ProductImagesManager:IProductImagesService
    {
        private IProductImageDal _productImageDal;

        public ProductImagesManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult AddAsync(List<IFormFile> file, ProductsImage productsImage)
        {
            var error = "";
            List<ProductsImage> products = new List<ProductsImage>();
            var imageCount = _productImageDal.GetAll(c => c.ProductId == productsImage.ProductId).Count;
            if (imageCount >= 5)
            {
                return new ErrorResult("One product must have 5 or less images");
            }

            for (int i = 0; i < file.Count; i++)
            {
                var newImage = new ProductsImage() { ProductId= productsImage.ProductId};
                var imageResult = FileHelper.Upload(file[i]);

                if (!imageResult.Success)
                {
                    error = imageResult.Message;
                    break;
                }
                else
                {
                    newImage.ImagePath = imageResult.Message;

                    products.Add(newImage);
                }
            }
            
            _productImageDal.MultiAddAsync(products.ToArray());
            return new SuccessResult("Product image added");
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult DeleteById(int id)
        {
            var images = _productImageDal.Get(c => c.Id == id);
            _productImageDal.DeleteAsync(images);
            return new SuccessResult();
        }


        public IResult Add(IFormFile file, ProductsImage entity)
        {
            throw new NotImplementedException();
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(ProductsImage productsImage)
        {
            _productImageDal.DeleteAsync(productsImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductImagesValidator))]
        public IResult Update(IFormFile file, ProductsImage productsImage)
        {
            _productImageDal.UpdateAsync(productsImage);
            return new SuccessResult();
        }

        public IDataResult<ProductsImage> Get(int id)
        {
            return new SuccessDataResult<ProductsImage>(_productImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<ProductsImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductsImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductsImage>> GetImagesByTId(int id)
        {
            throw new System.NotImplementedException();
        }
        //business rules

        private IResult CheckImageLimitExceeded(int productId)
        {
            var productsImageCount = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (productsImageCount >= 5)
            {
                return new ErrorResult("Limit");
            }

            return new SuccessResult();
        }

        private IDataResult<List<ProductsImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _productImageDal.GetAll(c => c.ProductId == id).Any();
                if (!result)
                {
                    List<ProductsImage> productsImages = new List<ProductsImage>();
                    productsImages.Add(new ProductsImage { ProductId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<ProductsImage>>(productsImages);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<ProductsImage>>(exception.Message);
            }

            return new SuccessDataResult<List<ProductsImage>>(_productImageDal.GetAll(p => p.ProductId == id).ToList());
        }
        private IResult CarImageDelete(ProductsImage carImage)
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