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
        [CacheRemoveAspect("IProductCommentService.Get")]
        public async Task<IDataResult<int>> GetIdAdd(ProductComment productComment)
        {
            await _productCommentDal.AddAsync(productComment);    
            return new SuccessDataResult<int>(productComment.Id,Messages.AddedComment);
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

        public async Task<IDataResult<List<ProductCommentDto>>> GetDetailByUserIdAndId(int userId, int id)
        {
            return new SuccessDataResult<List<ProductCommentDto>>(
                await _productCommentDal.GetProductCommentDetail(c => c.UserId == userId && c.Id == id));
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
            return new SuccessResult(Messages.AddedComment);
        }
        [CacheRemoveAspect("IProductCommentService.Get")]
        public async Task<IResult> Delete(ProductComment productComment)
        {
            await _productCommentDal.DeleteAsync(productComment);
            return new SuccessResult(Messages.CommentDeleted);
        }
        [CacheRemoveAspect("IProductCommentService.Get")]
        public async Task<IResult> Update(ProductComment productComment)
        {
            await _productCommentDal.UpdateAsync(productComment);
            return new SuccessResult(Messages.UpdatedComment);
        }
    }
}