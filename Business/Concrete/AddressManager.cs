using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    public class AddressManager:IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public async Task<IResult> Add(Address address)
        {
             await _addressDal.AddAsync(address);
            return new SuccessResult(Messages.AddressAdded);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        public async Task<IResult> Delete(Address address)
        {
           await _addressDal.DeleteAsync(address);
            return new SuccessResult(Messages.AddressDeleted);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public async Task<IResult> Update(Address address)
        {
            await _addressDal.UpdateAsync(address);
            return new SuccessResult(Messages.AddressUpdated);
        }
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public async Task<IDataResult<long>> GetIdAdd(Address address)
        {
            await _addressDal.AddAsync(address);
            return new SuccessDataResult<long>(address.Id);
        }

        [CacheAspect]
        public async Task<IDataResult<Address>> GetById(int id)
        {
            return new SuccessDataResult<Address>(await _addressDal.GetAsync(c => c.Id == id));
        }

        [CacheAspect]
        public async Task<IDataResult<List<Address>>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Address>>(await _addressDal.GetAllAsync(p => p.UserId == userId),"Kullanıcının adresi listelendi");
        }
        [CacheAspect]
        public async Task<IDataResult<List<Address>>> GetAllByCityId(int cityId)
        {
            return new SuccessDataResult<List<Address>>(await _addressDal.GetAllAsync(p => p.CityId == cityId),
                Messages.AddressFilterCityId);
        }

        [CacheAspect]
        public async Task<IDataResult<List<Address>>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(await _addressDal.GetAllAsync());
        }
    }
}