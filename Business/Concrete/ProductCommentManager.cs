using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductCommentManager:IProductCommentService
    {
        private IProductCommentDal _productCommentDal;

        public ProductCommentManager(IProductCommentDal productCommentDal)
        {
            _productCommentDal = productCommentDal;
        }
        [CacheAspect]
        public IDataResult<List<ProductComment>> GetAll()
        {
            return new SuccessDataResult<List<ProductComment>>(_productCommentDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<ProductCommentDto>> GetDetail()
        {
            return new SuccessDataResult<List<ProductCommentDto>>(_productCommentDal.GetProductCommentDetail());
        }
        [CacheAspect]
        public IDataResult<List<ProductCommentDto>> GetDetailByUserId(int userId)
        {
            return new SuccessDataResult<List<ProductCommentDto>>(_productCommentDal.GetProductCommentDetail(c=>c.UserId==userId));
        }
        [CacheAspect]
        public IDataResult<List<ProductCommentDto>> GetDetailByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductCommentDto>>(
                _productCommentDal.GetProductCommentDetail(c => c.ProductId == productId));
        }

        [CacheAspect]
        public IDataResult<List<ProductComment>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<ProductComment>>(_productCommentDal.GetAll(c => c.UserId == userId));
        }
        [CacheAspect]
        public IDataResult<List<ProductComment>> GetAllByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductComment>>(_productCommentDal.GetAll(c => c.ProductId == productId));
        }
        [CacheRemoveAspect("IProductCommentService.Get")]
        public IResult Add(ProductComment productComment)
        {
            _productCommentDal.Add(productComment);
            return new SuccessResult();
        }

        public IResult Delete(ProductComment productComment)
        {
            _productCommentDal.Delete(productComment);
            return new SuccessResult();
        }

        public IResult Update(ProductComment productComment)
        {
            _productCommentDal.Delete(productComment);
            return new SuccessResult();
        }
    }
}