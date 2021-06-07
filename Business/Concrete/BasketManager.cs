using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BasketManager:IBasketService
    {
        private IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }
        
        public async Task<IDataResult<List<Basket>>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>( await _basketDal.GetAllAsync());
        }

        public async Task<IDataResult<List<BasketDetailDto>>> GetBasketDetails()
        {
            return new SuccessDataResult<List<BasketDetailDto>>(await _basketDal.GetBasketDetails());
        }
        
        public async Task<IDataResult<List<BasketDetailDto>>> GetBasketDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<BasketDetailDto>>(await _basketDal.GetBasketDetails(c=>c.UserId==userId));
        }
       
        public async Task<IResult> Add(Basket basket)
        {
            await _basketDal.AddAsync(basket);
            return new SuccessResult(Messages.AddedBasket);
        }

        public async Task<IResult> Delete(Basket basket)
        {
            await _basketDal.DeleteAsync(basket);
            return new SuccessResult(Messages.DeletedBasket);
        }
        [CacheRemoveAspect("IBasketService.Get")]
        public async Task<IResult> Update(Basket basket)
        {
           await _basketDal.UpdateAsync(basket);
            return new SuccessResult(Messages.UpdatedBasket);
        }
    }
}