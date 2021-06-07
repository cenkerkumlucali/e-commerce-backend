using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IDataResult<List<ProductComment>>> GetAll()
        {
            return new SuccessDataResult<List<ProductComment>>(await _productCommentDal.GetAllAsync());
        }
        [CacheAspect]
        public async Task<IDataResult<List<ProductCommentDto>>> GetDetail()
        {
            return new SuccessDataResult<List<ProductCommentDto>>(await _productCommentDal.GetProductCommentDetail());
        }
        [CacheAspect]
        public async Task<IDataResult<List<ProductCommentDto>>> GetDetailByUserId(int userId)
        {
            return new SuccessDataResult<List<ProductCommentDto>>(await _productCommentDal.GetProductCommentDetail(c=>c.UserId==userId));
        }
        [CacheAspect]
        public async Task<IDataResult<List<ProductCommentDto>>> GetDetailByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductCommentDto>>(
               await _productCommentDal.GetProductCommentDetail(c => c.ProductId == productId));
        }

        [CacheAspect]
        public async Task<IDataResult<List<ProductComment>>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<ProductComment>>(await _productCommentDal.GetAllAsync(c => c.UserId == userId));
        }
        [CacheAspect]
        public async Task<IDataResult<List<ProductComment>>> GetAllByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductComment>>(await _productCommentDal.GetAllAsync(c => c.ProductId == productId));
        }
        [CacheRemoveAspect("IProductCommentService.Get")]
        public async Task<IResult> Add(ProductComment productComment)
        {
            await _productCommentDal.AddAsync(productComment);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(ProductComment productComment)
        {
            await _productCommentDal.DeleteAsync(productComment);
            return new SuccessResult();
        }

        public async Task<IResult> Update(ProductComment productComment)
        {
            await _productCommentDal.DeleteAsync(productComment);
            return new SuccessResult();
        }
    }
}