using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IDataResult<List<Country>>> GetAll()
        {
            return new ErrorDataResult<List<Country>>(await _countryDal.GetAllAsync());
        }

        public async Task<IResult> Add(Country country)
        {
            await _countryDal.AddAsync(country);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Country country)
        {
            await _countryDal.DeleteAsync(country);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Country country)
        {
            await _countryDal.UpdateAsync(country);
            return new SuccessResult();
        }
    }
}