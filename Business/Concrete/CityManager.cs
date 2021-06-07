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

namespace Business.Concrete
{
    public class CityManager:ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICityService.Get")]
        [ValidationAspect(typeof(CityValidator))]
        public async Task<IResult> Add(City city)
        {
            await _cityDal.AddAsync(city);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(City city)
        {
            await _cityDal.DeleteAsync(city);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICityService.Get")]
        [ValidationAspect(typeof(CityValidator))]
        public async Task<IResult> Update(City city)
        {
            await _cityDal.UpdateAsync(city);
            return new SuccessResult();
        }
        public async Task<IDataResult<List<City>>> GetAll()
        {
            return new SuccessDataResult<List<City>>(await _cityDal.GetAllAsync());
        }
       
    }
}