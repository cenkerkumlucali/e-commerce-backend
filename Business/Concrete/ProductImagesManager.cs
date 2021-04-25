using System;
using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Business.Concrete
{
    public class ProductImagesManager:IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImagesManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IResult Add(IFormFile file, ProductsImage productsImage)
        {
            var imageCount = _productImageDal.GetAll(c => c.ProductId == productsImage.ProductId).Count;
            if (imageCount >= 5)
            {
                return new ErrorResult("One product must have 5 or less images");
            }
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            productsImage.ImagePath = imageResult.Message;
            _productImageDal.Add(productsImage);
            return new SuccessResult("Product image added");
        }

        public IResult Delete(ProductsImage productsImage)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(IFormFile file, ProductsImage productsImage)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<ProductsImage> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<ProductsImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductsImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductsImage>> GetImagesByProductId(int id)
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