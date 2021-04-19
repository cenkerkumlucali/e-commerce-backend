using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CountryManager:ICountryService
    {
        private ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new ErrorDataResult<List<Country>>(_countryDal.GetAll());
        }

        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult();
        }

        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult();
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult();
        }
    }
}