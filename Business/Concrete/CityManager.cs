using System.Collections.Generic;
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
        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICityService.Get")]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult();
        }
        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll());
        }
       
    }
}