using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
        public IDataResult<List<ProductComment>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<ProductComment>>(_productCommentDal.GetAll(c => c.UserId == userId));
        }
        [CacheAspect]
        public IDataResult<List<ProductComment>> GetAllByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductComment>>(_productCommentDal.GetAll(c => c.ProductId == productId));
        }

        public IResult Add(ProductComment productComment)
        {
            _productCommentDal.Add(productComment);
            return new SuccessResult();
        }
    }
}