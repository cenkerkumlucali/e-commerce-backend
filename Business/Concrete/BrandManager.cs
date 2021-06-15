using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public async Task<IResult> Add(Brand brand)
        {
          await _brandDal.AddAsync(brand);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Brand brand)
        {
            await _brandDal.DeleteAsync(brand);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public async Task<IResult> Update(Brand brand)
        {
           await _brandDal.UpdateAsync(brand);
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<List<Brand>>> GetAll()
        {
           
                return new SuccessDataResult<List<Brand>>(await _brandDal.GetAllAsync());
            

        }
        [CacheAspect]
        public async Task<IDataResult<List<BrandDetailDto>>> GetBrandDetails()
        {
            return new SuccessDataResult<List<BrandDetailDto>>(await _brandDal.GetBrandsDetails());
        }

       
    }
}